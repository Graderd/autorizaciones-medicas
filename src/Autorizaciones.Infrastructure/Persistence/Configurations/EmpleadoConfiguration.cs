using Autorizaciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorizaciones.Infrastructure.Persistence.Configurations
{
    public class EmpleadoConfiguration
        : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("empleados");

            builder.HasKey(empleado => empleado.Id);

            builder.Property(empleado => empleado.PersonaId)
                .IsRequired();

            builder.HasOne<Persona>()
                .WithMany()
                .HasForeignKey(empleado => empleado.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(empleado => empleado.CodigoEmpleado)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(empleado => empleado.CodigoEmpleado)
                .IsUnique();

            builder.Property(empleado => empleado.EstaActivo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(empleado => empleado.FechaCreacion)
                .IsRequired();

            builder.Property(empleado => empleado.UsuarioCreacionId)
                .IsRequired(false);

            builder.Property(empleado => empleado.FechaActualizacion)
                .IsRequired(false);

            builder.Property(empleado => empleado.UsuarioActualizacionId)
                .IsRequired(false);

            builder.Property(empleado => empleado.FechaInactivacion)
                .IsRequired(false);

            builder.Property(empleado => empleado.UsuarioInactivacionId)
                .IsRequired(false);

            builder.Property(empleado => empleado.Version)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}