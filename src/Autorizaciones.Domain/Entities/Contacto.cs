using System;
using System.Net.Mail;

namespace Autorizaciones.Domain.Entities
{
    public class Contacto : EntidadAuditable
    {
        public long? PersonaId { get; private set; }
        public long? EmpresaId {get; private set;}
        public string? CorreoElectronico {get; private set;}

        public Contacto(
        long? personaId,
        long? empresaId,
        string? correoElectronico = null)
        {
            //Debe pertenecer a una persona o a una empresa, nunca a ambas.
            if(personaId.HasValue == empresaId.HasValue)
                throw new ArgumentException(
                    "El contacto debe estar asociado a una persona o a una empresa, pero no a ambas.");

            if (personaId.HasValue && personaId.Value <= 0)
                throw new ArgumentException(
                    "El ID de la persona debe ser mayor que cero.");

            if (empresaId.HasValue && empresaId.Value <= 0)
                throw new ArgumentException(
                    "El ID de la empresa debe ser mayor que cero.");

            if (correoElectronico?.Trim().Length > 150)
                throw new ArgumentException(
                    "El correo electrónico no puede superar los 150 caracteres.");

            if (!string.IsNullOrWhiteSpace(correoElectronico))
            {
                try
                {
                    var correo = new MailAddress(correoElectronico.Trim());

                    if (correo.Address != correoElectronico.Trim())
                        throw new ArgumentException(
                            "El correo electrónico no tiene un formato válido.");
                }
                catch (FormatException)
                {
                    throw new ArgumentException(
                        "El correo electrónico no tiene un formato válido.");
                }
            }

            PersonaId = personaId;
            EmpresaId = empresaId;
            CorreoElectronico = string.IsNullOrWhiteSpace(correoElectronico)
                ? null
                : correoElectronico.Trim();
        }
    }

}