
using System;
using Autorizaciones.Domain.Entities;
using Xunit;

namespace Autorizaciones.Domain.Tests
{
    public class PersonaTests
    {
        [Fact]
        public void Constructor_DatosValidos_CreaPersonaCorrectamente()
        {
            // Arrange
            var fechaNacimiento = new DateTime(1997, 5, 15);

            // Act
            var persona = new Persona(
                "Juan",
                "Perez",
                fechaNacimiento,
                "00112345678",
                "8095551234",
                "Santo Domingo"
            );

            // Assert
            Assert.Equal("Juan", persona.Nombre);
            Assert.Equal("Perez", persona.Apellido);
            Assert.Equal(fechaNacimiento, persona.FechaNacimiento);
            Assert.Equal("00112345678", persona.Cedula);
            Assert.Equal("8095551234", persona.Telefono);
            Assert.Equal("Santo Domingo", persona.Direccion);
        }

        [Fact]
        public void Constructor_NombreVacio_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "",
                    "Perez",
                    new DateTime(1997, 5, 15),
                    "00112345678"
                )
            );
        }

        [Fact]
        public void Constructor_ApellidoVacio_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "Juan",
                    "",
                    new DateTime(1997, 5, 15),
                    "00112345678"
                )
            );
        }

        [Fact]
        public void Constructor_FechaNacimientoFutura_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "Juan",
                    "Perez",
                    DateTime.UtcNow.AddDays(1),
                    "00112345678"
                )
            );
        }

        [Fact]
        public void Constructor_CedulaConLongitudIncorrecta_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "Juan",
                    "Perez",
                    new DateTime(1997, 5, 15),
                    "12345"
                )
            );
        }

        [Fact]
        public void Constructor_SinTelefonoNiDireccion_AceptaValoresNulos()
        {
            var persona = new Persona(
                "Juan",
                "Perez",
                new DateTime(1997, 5, 15),
                "00112345678"
            );

            Assert.Null(persona.Telefono);
            Assert.Null(persona.Direccion);
        }

        [Fact]
        public void Constructor_NombreConEspacios_EliminaEspaciosExternos()
        {
            var persona = new Persona(
                "  Juan  ",
                "  Perez  ",
                new DateTime(1997, 5, 15),
                "00112345678"
            );

            Assert.Equal("Juan", persona.Nombre);
            Assert.Equal("Perez", persona.Apellido);
        }


        [Fact]
        public void Constructor_NombreMayorA100Caracteres_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    new string('A', 101),
                    "Perez",
                    new DateTime(1997, 5, 15),
                    "00112345678"
                )
            );
        }

        [Fact]
        public void Constructor_ApellidoMayorA100Caracteres_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "Juan",
                    new string('A', 101),
                    new DateTime(1997, 5, 15),
                    "00112345678"
                )
            );
        }

        [Fact]
        public void Constructor_TelefonoMenorA10Digitos_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "Juan",
                    "Perez",
                    new DateTime(1997, 5, 15),
                    "00112345678",
                    "809555123"
                )
            );
        }

        [Fact]
        public void Constructor__Mayora10Digitos_LanzarExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "Maria",
                    "Olivares",
                    new DateTime(1965, 4, 28),
                    "00122334898",
                    "80955512345"
                )
            );
        }

        [Fact]
        public void Constructor_TelefonoConLetras_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "Carlos",
                    "Ortega",
                    new DateTime(1980, 7, 12),
                    "00117434810",
                    "809ABC1234"
                )
            );
        }

        [Fact]
        public void Constructor_TelefonoConEspacio()
        {
            // Arrange
            var fechaNacimiento = new DateTime(1997, 5, 15);

            // Act
            var persona = new Persona(
                "Karina",
                "Perez",
                fechaNacimiento,
                "00111344412",
                "  8095551234  ",
                "Santo Domingo"
            );

            // Assert
            Assert.Equal("Karina", persona.Nombre);
            Assert.Equal("Perez", persona.Apellido);
            Assert.Equal(fechaNacimiento, persona.FechaNacimiento);
            Assert.Equal("00111344412", persona.Cedula);
            Assert.Equal("8095551234", persona.Telefono);
            Assert.Equal("Santo Domingo", persona.Direccion);
        }

        [Fact]
        public void Constructor_DireccionMayorA250Caracteres_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Persona(
                    "Juan",
                    "Perez",
                    new DateTime(1997, 5, 15),
                    "00112345678",
                    direccion: new string('A', 251)
                )
            );
        }

        [Fact]
        public void Constructor_TelefonoConEspacios_LoEstableceComoNull()
        {
            var persona = new Persona(
                "Karina",
                "Perez",
                new DateTime(1997, 5, 15),
                "00111344412",
                "     "
            );

            Assert.Null(persona.Telefono);
        }

    }
}
