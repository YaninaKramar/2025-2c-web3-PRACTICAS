namespace Practica1.Logica;

public class JuegoAhorcado
{
    private static List<string> palabras = new List<string> ()
    { "programacion", "desarrollo", "computadora", "teclado", "raton" };

    //lógica del juego del ahorcado
    private string _palabraAAdivinar;
    private string _palabraOculta;
    private int _intentosRestantes = 6;

    public string PalabraAAdivinar
    {
        get { return _palabraAAdivinar; }
    }
    public void ElegirPalabra()
    {
        Random random = new Random();
        _palabraAAdivinar = palabras[random.Next(palabras.Count)];
        _palabraOculta = new string('_', _palabraAAdivinar.Length);
    }
    public string MostrarPalabraOculta()
    {
        return _palabraOculta;
    }
    
    public int IntentosRestantes()
    {
        return _intentosRestantes;
    }
    public bool AdivinarLetra(char letra)
    {
        letra = char.ToLower(letra);
        if (_palabraAAdivinar.Contains(letra))
        {
            char[] letrasAdivinadas = _palabraOculta.ToCharArray();
            for (int i = 0; i < _palabraAAdivinar.Length; i++)
            {
                if (_palabraAAdivinar[i] == letra)
                {
                    letrasAdivinadas[i] = letra;
                }
            }
            _palabraOculta = new string(letrasAdivinadas);
            return true;
        }
        else
        {
            _intentosRestantes--;
            return false;
        }
    }
    public bool JuegoTerminado()
    {
        if(_intentosRestantes <= 0 || _palabraOculta == _palabraAAdivinar)
            return true;
        else
            return false;
    }
}
