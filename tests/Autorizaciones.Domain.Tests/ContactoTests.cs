
using System;
using Autorizaciones.Domain.Entities;
using Xunit;

namespace Autorizaciones.Domain.Tests
{
    public class ContactoTests
    {
        [Fact]
        public void Constructor_ConPersonaValida_CreaContacto()
        {
            var contacto = new Contacto(1, null, "persona@correo.com");

            Assert.Equal(1, contacto.PersonaId);
            Assert.Null(contacto.EmpresaId);
            Assert.Equal("persona@correo.com", contacto.CorreoElectronico);
        }

        [Fact]
        public void Constructor_ConEmpresaValida_CreaContacto()
        {
            var contacto = new Contacto(null, 5, "empresa@correo.com");

            Assert.Null(contacto.PersonaId);
            Assert.Equal(5, contacto.EmpresaId);
            Assert.Equal("empresa@correo.com", contacto.CorreoElectronico);
        }

        [Fact]
        public void Constructor_SinPersonaNiEmpresa_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(
                () => new Contacto(null, null));
        }

        [Fact]
        public void Constructor_ConPersonaYEmpresa_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(
                () => new Contacto(1, 5));
        }

        [Fact]
        public void Constructor_ConPersonaIdCero_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(
                () => new Contacto(0, null));
        }

        [Fact]
        public void Constructor_ConEmpresaIdNegativo_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(
                () => new Contacto(null, -1));
        }

        [Fact]
        public void Constructor_SinCorreo_CreaContactoConCorreoNulo()
        {
            var contacto = new Contacto(1, null);

            Assert.Null(contacto.CorreoElectronico);
        }

        [Fact]
        public void Constructor_ConCorreoVacio_LoConvierteEnNulo()
        {
            var contacto = new Contacto(1, null, " ");

            Assert.Null(contacto.CorreoElectronico);
        }

        [Fact]
        public void Constructor_ConCorreoInvalido_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(
                () => new Contacto(1, null, "correo-invalido"));
        }

        [Fact]
        public void Constructor_ConCorreoMayorA150Caracteres_LanzaExcepcion()
        {
            var correo = new string('a', 142) + "@test.com";

            Assert.Throws<ArgumentException>(
                () => new Contacto(1, null, correo));
        }

        [Fact]
        public void Constructor_ConCorreoConEspacios_EliminaEspacios()
        {
            var contacto = new Contacto(
                1,
                null,
                " persona@correo.com ");

            Assert.Equal("persona@correo.com", contacto.CorreoElectronico);
        }
    }
}
