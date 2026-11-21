using Autorizaciones.Domain.Entities;

namespace Autorizaciones.Domain.Tests;

public class UsuarioTest
{
    [Fact]
    public void CrearUsuario_ConDatosValidos_DebeCrearUsuarioActivo()
    {
        // Arrange
        var usuario = new Usuario(
            "admin",
            "admin@soa.com",
            "hash-de-prueba"
        );

        // Act y Assert
        Assert.Equal("admin", usuario.NombreUsuario);
        Assert.Equal("admin@soa.com", usuario.CorreoElectronico);
        Assert.Equal("hash-de-prueba", usuario.HashContrasena);
        Assert.True(usuario.EstaActivo);
        Assert.Equal(1, usuario.Version);
    }

    [Fact]
    public void CrearUsuario_ConCorreoVacio_DebeLanzarExcepcion()
    {
        // Arrange
        var nombreUsuario = "admin";
        var correoElectronico = "";
        var hashContrasena = "hash-de-prueba";

        // Act y Assert
        Assert.Throws<ArgumentException>(() =>
            new Usuario(
                nombreUsuario,
                correoElectronico,
                hashContrasena
            )
        );
    }

    [Fact]
    public void CrearUsuario_ConCorreoMayorA150Caracteres_DebeLanzarExcepcion()
    {
        // Arrange
        var correoElectronico = new string('a', 151);

        // Act y Assert
        Assert.Throws<ArgumentException>(() =>
            new Usuario(
                "admin",
                correoElectronico,
                "hash-de-prueba"
            )
        );
    }
}