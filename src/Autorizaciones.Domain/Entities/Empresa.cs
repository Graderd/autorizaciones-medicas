using System;

namespace Autorizaciones.Domain.Entities
{
    public class Empresa : EntidadAuditable
    {
        public string Nombre {get; private set;}
        public DateTime FechaConstitucion {get; private set;}
        public string RNC {get; private set;}
        public string? Telefono {get; private set;}
        public string? Direccion {get; private set;}

        public Empresa(
        string nombre,
        DateTime fechaConstitucion,
        string rNC,
        string? telefono = null,
        string? direccion = null)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio");
            
            if(nombre.Trim().Length > 150)
                throw new ArgumentException("El nombre no puede superar los 150 caracteres");

            if (fechaConstitucion == default)
                throw new ArgumentException("La fecha de constitucionc es obligatoria");

            if (fechaConstitucion.Date > DateTime.UtcNow.Date)
                throw new ArgumentException("La fecha de constitución es obligatoria");

            if (string.IsNullOrWhiteSpace(rNC))
                throw new ArgumentException("El RNC es obligatorio");

            if (rNC.Trim().Length != 9)
                throw new ArgumentException("El RNC es invalido");

            if (telefono?.Trim().Length > 11)
                throw new ArgumentException("El teléfono no puede superar los 11 caracteres");

            if (direccion?.Trim().Length > 250)
                throw new ArgumentException("La dirección no puede superar los 250 caracteres");

            Nombre = nombre.Trim();
            FechaConstitucion = fechaConstitucion.Date;
            RNC = rNC.Trim();
            Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim();
            Direccion = string.IsNullOrWhiteSpace(direccion) ? null : direccion.Trim();
        }

    }
}