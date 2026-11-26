
using Autorizaciones.Domain.Entities;
using Autorizaciones.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Autorizaciones.Infrastructure.Persistence.Conventions;

namespace Autorizaciones.Infrastructure.Persistence.Context
{
    public class AutorizacionesDbContext
        : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public AutorizacionesDbContext(
            DbContextOptions<AutorizacionesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados => Set<Empleado>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AutorizacionesDbContext).Assembly);

            SnakeCaseConvention.Apply(modelBuilder);
        }
    }
}
