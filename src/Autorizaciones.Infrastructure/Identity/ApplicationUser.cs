using System;
using Microsoft.AspNetCore.Identity;
using Autorizaciones.Domain.Entities;

namespace Autorizaciones.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public long EmpleadoId { get; set; }

        public Empleado Empleado { get; set; } = null!;

        public DateTime FechaCreacion { get; set; }

        public long? UsuarioCreacionId { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public long? UsuarioActualizacionId { get; set; }

        public DateTime? FechaInactivacion { get; set; }

        public long? UsuarioInactivacionId { get; set; }

        public long Version { get; set; } = 1;

        public bool EstaActivo { get; set; } = true;
    }
}
