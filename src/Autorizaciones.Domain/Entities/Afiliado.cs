
using System;

namespace Autorizaciones.Domain.Entities
{
    public class Afiliado : EntidadAuditable
    {
        public string NumeroAfiliado { get; private set; }
        public long PersonaId { get; private set; }

        public Afiliado(string numeroAfiliado, long personaId)
        {
            if (string.IsNullOrWhiteSpace(numeroAfiliado))
                throw new ArgumentException(
                    "El número de afiliado es obligatorio");

            if (numeroAfiliado.Trim().Length > 20)
                throw new ArgumentException(
                    "El número de afiliado no puede superar los 20 caracteres");

            if (personaId <= 0)
                throw new ArgumentException(
                    "El ID de la persona debe ser mayor que cero");

            NumeroAfiliado = numeroAfiliado.Trim();
            PersonaId = personaId;
        }
    }
}
