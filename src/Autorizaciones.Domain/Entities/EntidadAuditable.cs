using System;

namespace Autorizaciones.Domain.Entities
{
    public abstract class EntidadAuditable : EntidadBase
    {
        public DateTime FechaCreacion { get; protected set; }

        public long? UsuarioCreacionId { get; protected set; }

        public DateTime? FechaActualizacion { get; protected set; }

        public long? UsuarioActualizacionId { get; protected set; }

        public DateTime? FechaInactivacion { get; protected set; }

        public long? UsuarioInactivacionId { get; protected set; }

        public long Version { get; protected set; } = 1;

        public void RegistrarActualizacion(long usuarioId)
        {
            if(usuarioId <= 0)
            {
                throw new ArgumentException(
            "El ID del usuario debe ser mayor que cero"
        );
            }

        FechaActualizacion = DateTime.UtcNow;
        UsuarioActualizacionId = usuarioId;
        Version++;
        }
    }
}