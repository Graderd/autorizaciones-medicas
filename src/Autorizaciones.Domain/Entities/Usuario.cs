using System;
namespace Autorizaciones.Domain.Entities
{
    public class Usuario : EntidadAuditable
    {
        public string NombreUsuario {get; private set;}
        public string CorreoElectronico {get; private set;}
        public string HashContrasena {get; private set;}
        public bool EstaActivo {get; private set;}

        public Usuario(
        string nombreUsuario,
        string correoElectronico,
        string hashContrasena
    )
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException(
                    "El nombre de usuario es obligatorio"
                );
            }
            if (nombreUsuario.Length > 50)
            {
                throw new ArgumentException(
                    "El nombre de usuario no puede superar los 50 caracteres"
                );
            }

            if (string.IsNullOrWhiteSpace(correoElectronico))
            {
                throw new ArgumentException(
                    "El correo electronico es obligatorio"
                );
            }

            if (correoElectronico.Length > 150)
            {
                throw new ArgumentException(
                    "El correo electrónico no puede superar los 150 caracteres"
                );
            }

            if (string.IsNullOrWhiteSpace(hashContrasena))
            {
                throw new ArgumentException(
                    "El hash de la contraseña es obligatorio"
                );
            }

            if (hashContrasena.Length > 255)
            {
                throw new ArgumentException(
                    "El hash de la contraseña no puede superar los 255 caracteres"
                );
            }

            NombreUsuario = nombreUsuario.Trim();
            CorreoElectronico = correoElectronico.Trim();
            HashContrasena = hashContrasena;
            EstaActivo = true;
        }

        public void CambiarCorreoElectronico(
            string nuevoCorreoElectronico,
            long usuarioActualizacionId)
        {
            if (string.IsNullOrWhiteSpace(nuevoCorreoElectronico))
            {
                throw new ArgumentException(
                    "El correo electronico es obligatorio"
                );
            }

            nuevoCorreoElectronico = nuevoCorreoElectronico.Trim();

            if(nuevoCorreoElectronico.Length > 150)
            {
                throw new ArgumentException(
                    "El correo electrónico no puede superar los 150 caracteres"
                );
            }

            if (CorreoElectronico.Equals(
                nuevoCorreoElectronico,
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El nuevo correo electrónico es igual al actual"
                );
            }

            RegistrarActualizacion(usuarioActualizacionId);
            CorreoElectronico = nuevoCorreoElectronico;
        }
    }

}