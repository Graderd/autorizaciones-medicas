using System;

namespace Autorizaciones.Domain.Entities
{
    public class Empleado : EntidadAuditable
    {
        public long PersonaId {get; private set;}
        public string CodigoEmpleado {get; private set;}
        public bool EstaActivo {get; private set;}

        public Empleado(
            long personaId,
            string codigoEmpleado
        )
        {
            if (personaId <= 0)
                throw new ArgumentException(
                    "El ID de la persona debe ser mayor que cero");

            if (string.IsNullOrWhiteSpace(codigoEmpleado))
                throw new ArgumentException(
                    "El código del empleado es obligatorio");

            if (codigoEmpleado.Trim().Length > 20)
                throw new ArgumentException(
                    "El código del empleado no puede superar los 20 caracteres");

            PersonaId = personaId;
            CodigoEmpleado = codigoEmpleado.Trim();
            EstaActivo = true;
        }

        public void Inactivar(long usuarioId)
        {
            if (!EstaActivo)
                throw new InvalidOperationException(
                    "El empleado ya se encuentra inactivo");

            RegistrarInactivacion(usuarioId);
            EstaActivo = false;
        }

        public void Activar(long usuarioId)
        {
            if (EstaActivo)
                throw new InvalidOperationException(
                    "El empleado ya se encuentra activo");

            RegistrarReactivacion(usuarioId);
            EstaActivo = true;
        }

    }
}