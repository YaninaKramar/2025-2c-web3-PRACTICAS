namespace Practica1.Test;

public class JuegoAhorcadoTest
{
    [Fact]
    public void TestElegirPalabra_NoSeaNullNiEmpty()
    {
        // Arrange
        var juego = new Practica1.Logica.JuegoAhorcado();
        // Act
        juego.ElegirPalabra();
        var palabra = juego.PalabraAAdivinar;
        // Assert
        Assert.False(string.IsNullOrEmpty(palabra));
        Assert.All(palabra, c => Assert.InRange(c, 'a', 'z'));
    }

    [Fact]
    public void AdivinarLetra_Correcta_ActualizaPalabraOculta()
    {
        // Arrange
        var juego = new Practica1.Logica.JuegoAhorcado();
        juego.ElegirPalabra();
        var palabra = juego.PalabraAAdivinar;
        var letra = palabra[0]; // Tomar la primera letra de la palabra
        // Act
        var resultado = juego.AdivinarLetra(letra);
        var palabraOculta = juego.MostrarPalabraOculta();
        // Assert
        Assert.True(resultado);
        Assert.Contains(letra, palabraOculta);
    }

    [Theory]
    [InlineData('1')]
    public void AdivinarLetra_Incorrecta_DecrementaIntentos(char letra)
    {
        // Arrange
        var juego = new Practica1.Logica.JuegoAhorcado();
        juego.ElegirPalabra();
        var intentosIniciales = juego.IntentosRestantes();
        // Act
        var resultado = juego.AdivinarLetra(letra);
        var intentosDespues = juego.IntentosRestantes();
        // Assert
        Assert.False(resultado);
        Assert.Equal(intentosIniciales - 1, intentosDespues);
    }

    [Fact]
    public void JuegoTerminado_GanaElJuego()
    {
        // Arrange
        var juego = new Practica1.Logica.JuegoAhorcado();
        juego.ElegirPalabra();
        var palabra = juego.PalabraAAdivinar;
        // Act
        foreach (var letra in palabra.Distinct())
        {
            juego.AdivinarLetra(letra);
        }
        var terminado = juego.JuegoTerminado();
        // Assert
        Assert.True(terminado);
    }

    [Fact]
    public void JuegoTerminadoDeberiaSerTrueCuandoSeAlcanzaElLimiteDeIntentos()
    {
        // Arrange
        var juego = new Practica1.Logica.JuegoAhorcado();
        juego.ElegirPalabra();
        // Act
        for (int i = 0; i < 6; i++)
        {
            juego.AdivinarLetra('1'); // Letra incorrecta para reducir intentos
        }
        var terminado = juego.JuegoTerminado();
        // Assert
        Assert.True(terminado);
    }

    [Fact]
    public void MostrarPalabraOculta_DeberiaMostrarGuionesInicialmente()
    {
        // Arrange
        var juego = new Practica1.Logica.JuegoAhorcado();
        juego.ElegirPalabra();
        var palabra = juego.PalabraAAdivinar;
        // Act
        var palabraOculta = juego.MostrarPalabraOculta();
        // Assert
        Assert.Equal(new string('_', palabra.Length), palabraOculta);
    }

    [Fact]
    public void IntentosRestantes_DeberiaSer6AlIniciarElJuego()
    {
        // Arrange
        var juego = new Practica1.Logica.JuegoAhorcado();
        juego.ElegirPalabra();
        // Act
        var intentos = juego.IntentosRestantes();
        // Assert
        Assert.Equal(6, intentos);
    }

}
