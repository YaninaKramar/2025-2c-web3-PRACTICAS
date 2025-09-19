// logica para el juego ahorcado
//se permite 6 errores
using Practica1.Logica;

//string[] palabras = { "programacion", "desarrollo", "computadora", "teclado", "raton" };
//Random random = new Random();
//string palabraSecreta = palabras[random.Next(palabras.Length)];
//char[] letrasAdivinadas = new char[palabraSecreta.Length];
//for (int i = 0; i < letrasAdivinadas.Length; i++)
//{
//    letrasAdivinadas[i] = '_';
//}
//int intentosRestantes = 6;
//List<char> letrasErroneas = new List<char>();
Console.WriteLine("¡Bienvenido al juego del Ahorcado!");
//while (intentosRestantes > 0 && new string(letrasAdivinadas) != palabraSecreta)
//{
//    Console.WriteLine($"\nPalabra: {new string(letrasAdivinadas)}");
//    Console.WriteLine($"Intentos restantes: {intentosRestantes}");
//    Console.WriteLine($"Letras erróneas: {string.Join(", ", letrasErroneas)}");
//    Console.Write("Adivina una letra: ");
//    char letraAdivinada = Char.ToLower(Console.ReadKey().KeyChar);
//    Console.WriteLine();
//    if (palabraSecreta.Contains(letraAdivinada))
//    {
//        for (int i = 0; i < palabraSecreta.Length; i++)
//        {
//            if (palabraSecreta[i] == letraAdivinada)
//            {
//                letrasAdivinadas[i] = letraAdivinada;
//            }
//        }
//    }
//    else
//    {
//        if (!letrasErroneas.Contains(letraAdivinada))
//        {
//            letrasErroneas.Add(letraAdivinada);
//            intentosRestantes--;
//        }
//        else
//        {
//            Console.WriteLine("Ya has adivinado esa letra errónea. Intenta con otra.");
//        }
//    }
//}
//if (new string(letrasAdivinadas) == palabraSecreta)
//{
//    Console.WriteLine($"\n¡Felicidades! Has adivinado la palabra: {palabraSecreta}");
//}
//else
//{
//    Console.WriteLine($"\n¡Has perdido! La palabra era: {palabraSecreta}");
//}
//Console.WriteLine("Gracias por jugar al Ahorcado. ¡Hasta la próxima!");

JuegoAhorcado juego = new JuegoAhorcado();
juego.ElegirPalabra();
Console.WriteLine("Palabra a adivinar: " + juego.MostrarPalabraOculta());
Console.WriteLine("Intentos restantes: " + juego.IntentosRestantes());

while (juego.IntentosRestantes() > 0 && juego.MostrarPalabraOculta().Contains('_'))
{
    Console.Write("Introduce una letra: ");
    char letra = Char.ToLower(Console.ReadKey().KeyChar);
    Console.WriteLine();
    if(juego.AdivinarLetra(letra))
    {
        if (juego.JuegoTerminado())
        {
            Console.WriteLine("¡Felicidades! Has adivinado la palabra: " + juego.MostrarPalabraOculta());
            break;
        }
        Console.WriteLine("¡Correcto! La palabra oculta ahora es: " + juego.MostrarPalabraOculta());
    }
    else if(juego.JuegoTerminado())
    {
        Console.WriteLine("¡Has perdido! No te quedan intentos. La palabra era: " + juego.PalabraAAdivinar);
        break;
    }
    else
    {
        Console.WriteLine("¡Incorrecto! Te quedan " + juego.IntentosRestantes() + " intentos.");
        Console.WriteLine("Palabra oculta: " + juego.MostrarPalabraOculta());
    }
}

