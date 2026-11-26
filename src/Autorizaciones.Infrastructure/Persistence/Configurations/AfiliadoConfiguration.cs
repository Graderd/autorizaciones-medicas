
using Autorizaciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorizaciones.Infrastructure.Persistence.Configurations
{
    public class AfiliadoConfiguration
        : IEntityTypeConfiguration<Afiliado>
    {
        public void Configure(EntityTypeBuilder<Afiliado> builder)
        {
            builder.ToTable("afiliados");

            builder.HasKey(afiliado => afiliado.Id);

            builder.Property(afiliado => afiliado.NumeroAfiliado)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(afiliado => afiliado.NumeroAfiliado)
                .IsUnique();

            builder.Property(afiliado => afiliado.PersonaId)
                .IsRequired();

            builder.HasIndex(afiliado => afiliado.PersonaId)
                .IsUnique();

            builder.HasOne<Persona>()
                .WithMany()
                .HasForeignKey(afiliado => afiliado.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            EntidadAuditableConfiguration.Configure(builder);
        }
    }
}
