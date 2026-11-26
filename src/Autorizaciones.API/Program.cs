
using Autorizaciones.Infrastructure.Identity;
using Autorizaciones.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Autorizaciones.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("Oracle")
    ?? throw new InvalidOperationException(
        "No se encontró la cadena de conexión Oracle.");

builder.Services.AddDbContext<AutorizacionesDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole<long>>(options =>
    {
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AutorizacionesDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddOpenApi();

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//esto es temporal
if (app.Environment.IsDevelopment())
{
    app.MapGet("/diagnostico/oracle", async (
        AutorizacionesDbContext db) =>
    {
        var conectado = await db.Database.CanConnectAsync();

        return conectado
            ? Results.Ok("Conexión con Oracle exitosa.")
            : Results.Problem("No fue posible conectar con Oracle.");
    });

    app.MapGet("/diagnostico/modelo", (
    AutorizacionesDbContext db) =>
{
    var entidades = db.Model.GetEntityTypes()
        .Select(entity =>
        {
            var tabla = entity.GetTableName();

            if (tabla is null)
                return null;

            var storeObject = StoreObjectIdentifier.Table(
                tabla,
                entity.GetSchema());

            return new
            {
                Entidad = entity.ClrType.Name,
                Tabla = tabla,
                Columnas = entity.GetProperties()
                    .Select(property => new
                    {
                        Propiedad = property.Name,
                        Columna = property.GetColumnName(storeObject)
                    }),
                Indices = entity.GetIndexes()
                .Select(index => new
                {
                    Nombre = index.GetDatabaseName(),
                    Propiedades = index.Properties
                        .Select(property => property.Name),
                    EsUnico = index.IsUnique
                })
            };
        })
        .Where(entity => entity is not null);

    return Results.Ok(entidades);
});

    app.MapGet("/diagnostico/auditoria", (AutorizacionesDbContext db) =>
    {
        var relaciones = db.Model.GetEntityTypes()
            .Where(entity =>
                typeof(EntidadAuditable).IsAssignableFrom(entity.ClrType)
                || entity.ClrType == typeof(ApplicationUser))
            .Select(entity => new
            {
                Entidad = entity.ClrType.Name,

                Relaciones = entity.GetForeignKeys()
                    .Where(fk => fk.PrincipalEntityType.ClrType
                        == typeof(ApplicationUser))
                    .Select(fk => new
                    {
                        Propiedades = fk.Properties
                            .Select(property => property.Name),

                        EntidadReferenciada =
                            fk.PrincipalEntityType.ClrType.Name,

                        EsObligatoria = fk.IsRequired,
                        Eliminacion = fk.DeleteBehavior.ToString()
                    })
            });

        return Results.Ok(relaciones);
    });
}

app.Run();
