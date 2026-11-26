
using Autorizaciones.Domain.Entities;
using Autorizaciones.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorizaciones.Infrastructure.Persistence.Configurations
{
    public static class EntidadAuditableConfiguration
    {
        public static void Configure<TEntity>(
            EntityTypeBuilder<TEntity> builder)
            where TEntity : EntidadAuditable
        {
            builder.Property(entidad => entidad.FechaCreacion)
                .IsRequired();

            builder.Property(entidad => entidad.UsuarioCreacionId)
                .IsRequired(false);

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(entidad => entidad.UsuarioCreacionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(entidad => entidad.FechaActualizacion)
                .IsRequired(false);

            builder.Property(entidad => entidad.UsuarioActualizacionId)
                .IsRequired(false);

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(entidad => entidad.UsuarioActualizacionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(entidad => entidad.FechaInactivacion)
                .IsRequired(false);

            builder.Property(entidad => entidad.UsuarioInactivacionId)
                .IsRequired(false);

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(entidad => entidad.UsuarioInactivacionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(entidad => entidad.Version)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}
