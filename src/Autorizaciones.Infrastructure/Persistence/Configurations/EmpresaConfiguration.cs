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

            EntidadAuditableConfiguration.Configure(builder);
        }
    }
}