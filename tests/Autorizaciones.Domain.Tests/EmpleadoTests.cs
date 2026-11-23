using System.Reflection.Metadata;
using Autorizaciones.Domain.Entities;

namespace Autorizaciones.Domain.Tests;

public class EmpleadoTest
{
    [Fact]
    public void Constructor_DatosValidos_CreaEmpleadoCorrectamente()
    {
        // Arrange
        var empleado = new Empleado(
            1,
            "EMP-000001"
        );

        // Act y Assert
        Assert.Equal(1,empleado.PersonaId);
        Assert.Equal("EMP-000001", empleado.CodigoEmpleado);
        Assert.True(empleado.EstaActivo);
    }

    [Fact]
    public void CrearEmpleado_ConPersonalId_EnZero()
    {
        // Arrange
        var personalId = 0;
        var codigoEmpleado = "EMP-000002";

        // Act y Assert
        Assert.Throws<ArgumentException>(() =>
            new Empleado(
                personalId,
                codigoEmpleado
                
            )
        );
    }

    [Fact]
    public void Constructor_CodigoVacio_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Empleado(2, "")
        );
    }

    [Fact]
    public void Constructor_CodigoMayor20Caracteres_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
            new Empleado(
                3,
                new string('A', 21)
            )
        );
    }

    [Fact]
    public void CrearEmpleado_CodigoConEspacio()
    {
        var empleado = new Empleado(
            4,
            "   EMP-000004    "
        );

        // Act y Assert
        Assert.Equal(4, empleado.PersonaId);
        Assert.Equal("EMP-000004", empleado.CodigoEmpleado);
        Assert.True(empleado.EstaActivo);
    }

    [Fact]
    public void CrearEmpleado_Inactivo()
    {
        // Arrange
        var empleado = new Empleado(
            6,
            "EMP-000006"
        );

        // Act y Assert
        empleado.Inactivar(6);

        Assert.Equal(6, empleado.PersonaId);
        Assert.Equal("EMP-000006", empleado.CodigoEmpleado);
        Assert.False(empleado.EstaActivo);
        Assert.NotNull(empleado.FechaInactivacion);
        Assert.Equal(6, empleado.UsuarioInactivacionId);
        Assert.Equal(2, empleado.Version);
    }
    

    [Fact]
    public void Inactivar_EmpleadoInactivo()
    {
        var empleado = new Empleado(
            7,
            "EMP-000007"
        );

        // Act y Assert
        empleado.Inactivar(7);

        Assert.Throws<InvalidOperationException>(() =>
            empleado.Inactivar(
                7
            )
        );
    }

    [Fact]
    public void Activar_EmpleadoInactivo()
    {
        // Arrange
        var empleado = new Empleado(
            8,
            "EMP-000008"
        );

        // Act y Assert
        empleado.Inactivar(8);
        empleado.Activar(8);

        Assert.Equal(8, empleado.PersonaId);
        Assert.Equal("EMP-000008", empleado.CodigoEmpleado);
        Assert.True(empleado.EstaActivo);
        Assert.NotNull(empleado.FechaActualizacion);
        Assert.Equal(8, empleado.UsuarioActualizacionId);
        Assert.Equal(3, empleado.Version);
        Assert.Null(empleado.FechaInactivacion);
        Assert.Null(empleado.UsuarioInactivacionId);

    }

    [Fact]
    public void Activar_EmpleadoActivo()
    {
        var empleado = new Empleado(
            9,
            "EMP-000009"
        );

        // Act y Assert
        Assert.Throws<InvalidOperationException>(() =>
            empleado.Activar(
                9
            )
        );
    }

    [Fact]
    public void Usuario_Invalido_Inactivar()
    {
        // Arrange
        var empleado = new Empleado(
            11,
            "EMP-000011"
        );

        // Act y Assert
        Assert.Throws<ArgumentException>(() =>
            empleado.Inactivar(0)  
        );

        Assert.Equal(11, empleado.PersonaId);
        Assert.Equal("EMP-000011", empleado.CodigoEmpleado);
        Assert.True(empleado.EstaActivo);
        Assert.Equal(1, empleado.Version);
        Assert.Null(empleado.FechaInactivacion);
        Assert.Null(empleado.UsuarioInactivacionId);
    }

    [Fact]
    public void Usuario_Invalido_Activar()
    {
        // Arrange
        var empleado = new Empleado(
            12,
            "EMP-000012"
        );

        // Act y Assert
        empleado.Inactivar(12);
        Assert.Throws<ArgumentException>(() =>
            empleado.Activar(0)
        );

        Assert.Equal(12, empleado.PersonaId);
        Assert.Equal("EMP-000012", empleado.CodigoEmpleado);
        Assert.False(empleado.EstaActivo);
        Assert.NotNull(empleado.FechaInactivacion);
        Assert.Equal(12, empleado.UsuarioInactivacionId);
        Assert.Equal(2, empleado.Version);
    }
}