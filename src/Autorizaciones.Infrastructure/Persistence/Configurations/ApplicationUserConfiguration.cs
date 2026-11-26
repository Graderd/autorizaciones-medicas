
using Autorizaciones.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorizaciones.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration
        : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("AspNetUsers");

            builder.Property(usuario => usuario.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(usuario => usuario.NormalizedUserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(usuario => usuario.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(usuario => usuario.NormalizedEmail)
                .HasMaxLength(150);

            builder.HasIndex(usuario => usuario.NormalizedEmail)
                .IsUnique()
                .HasDatabaseName("EmailIndex");

            builder.HasOne(usuario => usuario.Empleado)
                .WithOne()
                .HasForeignKey<ApplicationUser>(
                    usuario => usuario.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(usuario => usuario.EmpleadoId)
                .IsRequired();

            builder.Property(usuario => usuario.EstaActivo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(usuario => usuario.Version)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(usuario => usuario.FechaCreacion)
                .IsRequired();

            builder.Property(usuario => usuario.UsuarioCreacionId)
                .IsRequired(false);

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(usuario => usuario.UsuarioCreacionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(usuario => usuario.FechaActualizacion)
                .IsRequired(false);

            builder.Property(usuario => usuario.UsuarioActualizacionId)
                .IsRequired(false);

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(usuario => usuario.UsuarioActualizacionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(usuario => usuario.FechaInactivacion)
                .IsRequired(false);

            builder.Property(usuario => usuario.UsuarioInactivacionId)
                .IsRequired(false);

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(usuario => usuario.UsuarioInactivacionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
