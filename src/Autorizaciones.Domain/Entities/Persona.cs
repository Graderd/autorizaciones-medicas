
using System;

namespace Autorizaciones.Domain.Entities
{
    public class Persona : EntidadAuditable
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public string Cedula { get; private set; }
        public string? Telefono { get; private set; }
        public string? Direccion { get; private set; }

        public Persona(
            string nombre,
            string apellido,
            DateTime fechaNacimiento,
            string cedula,
            string? telefono = null,
            string? direccion = null)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio");

            if (nombre.Trim().Length > 100)
                throw new ArgumentException("El nombre no puede superar los 100 caracteres");

            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido es obligatorio");

            if (apellido.Trim().Length > 100)
                throw new ArgumentException("El apellido no puede superar los 100 caracteres");

            if (fechaNacimiento == default)
                throw new ArgumentException("La fecha de nacimiento es obligatoria");

            if (fechaNacimiento.Date > DateTime.UtcNow.Date)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura");

            if (string.IsNullOrWhiteSpace(cedula))
                throw new ArgumentException("La cédula es obligatoria");

            if (cedula.Trim().Length != 11)
                throw new ArgumentException("La cédula debe tener exactamente 11 caracteres");

            if (telefono?.Trim().Length > 20)
                throw new ArgumentException("El teléfono no puede superar los 20 caracteres");

            if (direccion?.Trim().Length > 250)
                throw new ArgumentException("La dirección no puede superar los 250 caracteres");

            Nombre = nombre.Trim();
            Apellido = apellido.Trim();
            FechaNacimiento = fechaNacimiento.Date;
            Cedula = cedula.Trim();
            Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim();
            Direccion = string.IsNullOrWhiteSpace(direccion) ? null : direccion.Trim();
        }
    }
}
