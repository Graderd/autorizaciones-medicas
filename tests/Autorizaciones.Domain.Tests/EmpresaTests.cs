
using System;
using Autorizaciones.Domain.Entities;
using Xunit;

namespace Autorizaciones.Domain.Tests
{
    public class EmpresaTests
    {
        [Fact]
        public void Constructor_DatosValidos_CreaEmpresaCorrectamente()
        {
            var fecha = new DateTime(2010, 5, 15);

            var empresa = new Empresa(
                "  Empresa Dominicana  ",
                fecha,
                "101123456",
                "18095551234",
                "Santo Domingo"
            );

            Assert.Equal("Empresa Dominicana", empresa.Nombre);
            Assert.Equal(fecha, empresa.FechaConstitucion);
            Assert.Equal("101123456", empresa.RNC);
            Assert.Equal("18095551234", empresa.Telefono);
            Assert.Equal("Santo Domingo", empresa.Direccion);
        }

        [Fact]
        public void Constructor_NombreVacio_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Empresa("", new DateTime(2010, 5, 15), "101123456")
            );
        }

        [Fact]
        public void Constructor_NombreMayorA150Caracteres_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Empresa(
                    new string('A', 151),
                    new DateTime(2010, 5, 15),
                    "101123456"
                )
            );
        }

        [Fact]
        public void Constructor_FechaConstitucionNoValida_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Empresa("Empresa", default, "101123456")
            );
        }

        [Fact]
        public void Constructor_FechaConstitucionFutura_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Empresa(
                    "Empresa",
                    DateTime.UtcNow.AddDays(1),
                    "101123456"
                )
            );
        }

        [Fact]
        public void Constructor_RNCVacio_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Empresa("Empresa", new DateTime(2010, 5, 15), "")
            );
        }

        [Fact]
        public void Constructor_RNCConLongitudIncorrecta_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Empresa("Empresa", new DateTime(2010, 5, 15), "12345678")
            );
        }

        [Fact]
        public void Constructor_TelefonoMayorA20Caracteres_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Empresa(
                    "Empresa",
                    new DateTime(2010, 5, 15),
                    "101123456",
                    new string('1', 21)
                )
            );
        }

        [Fact]
        public void Constructor_DireccionMayorA250Caracteres_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Empresa(
                    "Empresa",
                    new DateTime(2010, 5, 15),
                    "101123456",
                    direccion: new string('A', 251)
                )
            );
        }

        [Fact]
        public void Constructor_SinTelefonoNiDireccion_AceptaValoresNulos()
        {
            var empresa = new Empresa(
                "Empresa Dominicana",
                new DateTime(2010, 5, 15),
                "101123456"
            );

            Assert.Null(empresa.Telefono);
            Assert.Null(empresa.Direccion);
        }
    }
}
