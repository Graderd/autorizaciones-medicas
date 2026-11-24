using Autorizaciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorizaciones.Infrastructure.Persistence.Configurations
{
    public class ContactoConfiguration
        : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.ToTable("contactos", tabla =>
            {
                tabla.HasCheckConstraint(
                    "CK_contactos_persona_empresa",
                    """
                    (persona_id IS NOT NULL AND empresa_id IS NULL)
                    OR
                    (persona_id IS NULL AND empresa_id IS NOT NULL)
                    """);
            });

            builder.HasKey(contacto => contacto.Id);

            builder.Property(contacto => contacto.PersonaId)
                .IsRequired(false);

            builder.HasOne<Persona>()
                .WithMany()
                .HasForeignKey(contacto => contacto.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(contacto => contacto.EmpresaId)
                .IsRequired(false);

            builder.HasOne<Empresa>()
                .WithMany()
                .HasForeignKey(contacto => contacto.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(contacto => contacto.CorreoElectronico)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(contacto => contacto.FechaCreacion)
                .IsRequired();

            builder.Property(contacto => contacto.UsuarioCreacionId)
                .IsRequired(false);

            builder.Property(contacto => contacto.FechaActualizacion)
                .IsRequired(false);

            builder.Property(contacto => contacto.UsuarioActualizacionId)
                .IsRequired(false);

            builder.Property(contacto => contacto.FechaInactivacion)
                .IsRequired(false);

            builder.Property(contacto => contacto.UsuarioInactivacionId)
                .IsRequired(false);

            builder.Property(contacto => contacto.Version)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}