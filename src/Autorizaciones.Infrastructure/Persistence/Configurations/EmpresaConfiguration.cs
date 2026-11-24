using Autorizaciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorizaciones.Infrastructure.Persistence.Configurations
{
    public class EmpresaConfiguration
        : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("empresas");

            builder.HasKey(empresa => empresa.Id);

            builder.Property(empresa => empresa.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(empresa => empresa.FechaConstitucion)
                .IsRequired();

            builder.Property(empresa => empresa.RNC)
                .HasMaxLength(9)
                .IsRequired();

            builder.HasIndex(empresa => empresa.RNC)
                .IsUnique();

            builder.Property(empresa => empresa.Telefono)
                .HasMaxLength(11)
                .IsRequired(false);

            builder.Property(empresa => empresa.Direccion)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(empresa => empresa.FechaCreacion)
                .IsRequired();

            builder.Property(empresa => empresa.UsuarioCreacionId)
                .IsRequired(false);

            builder.Property(empresa => empresa.FechaActualizacion)
                .IsRequired(false);

            builder.Property(empresa => empresa.UsuarioActualizacionId)
                .IsRequired(false);

            builder.Property(empresa => empresa.FechaInactivacion)
                .IsRequired(false);

            builder.Property(empresa => empresa.UsuarioInactivacionId)
                .IsRequired(false);

            builder.Property(empresa => empresa.Version)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}