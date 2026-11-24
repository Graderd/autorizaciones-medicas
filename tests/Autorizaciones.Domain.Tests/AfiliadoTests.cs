
using System;
using Autorizaciones.Domain.Entities;
using Xunit;

namespace Autorizaciones.Domain.Tests
{
    public class AfiliadoTests
    {
        [Fact]
        public void Constructor_DatosValidos_CreaAfiliadoCorrectamente()
        {
            // Arrange
            var numeroAfiliado = "AFI-000001";
            var personaId = 1;

            // Act
            var afiliado = new Afiliado(
                numeroAfiliado,
                personaId
            );

            // Assert
            Assert.Equal(numeroAfiliado, afiliado.NumeroAfiliado);
            Assert.Equal(personaId, afiliado.PersonaId);
        }

        [Fact]
        public void Constructor_NumeroAfiliadoVacio_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Afiliado("", 1)
            );
        }

        [Fact]
        public void Constructor_NumeroAfiliadoNulo_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Afiliado(null!, 1)
            );
        }

        [Fact]
        public void Constructor_NumeroAfiliadoConEspacios_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Afiliado("     ", 1)
            );
        }

        [Fact]
        public void Constructor_NumeroAfiliadoMayorA20Caracteres_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Afiliado(new string('A', 21), 1)
            );
        }

        [Fact]
        public void Constructor_PersonaIdCero_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Afiliado("AFI-000001", 0)
            );
        }

        [Fact]
        public void Constructor_PersonaIdNegativo_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Afiliado("AFI-000001", -1)
            );
        }

        [Fact]
        public void Constructor_NumeroAfiliadoConEspaciosExternos_EliminaEspacios()
        {
            // Arrange
            var numeroAfiliado = "  AFI-000001  ";

            // Act
            var afiliado = new Afiliado(numeroAfiliado, 1);

            // Assert
            Assert.Equal("AFI-000001", afiliado.NumeroAfiliado);
        }
    }
}
