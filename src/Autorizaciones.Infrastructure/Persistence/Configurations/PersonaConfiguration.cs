using Autorizaciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorizaciones.Infrastructure.Persistence.Configurations
{
    public class PersonaConfiguration
        : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("personas");

            builder.HasKey(persona => persona.Id);

            builder.Property(persona => persona.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(persona => persona.Apellido)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(persona => persona.FechaNacimiento)
                .IsRequired();

            builder.Property(persona => persona.Cedula)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(persona => persona.Cedula)
                .IsUnique();

            builder.Property(persona => persona.Telefono)
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(persona => persona.Direccion)
                .HasMaxLength(250)
                .IsRequired(false);

            EntidadAuditableConfiguration.Configure(builder);
        }
    }
}