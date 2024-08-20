using tarea_opentk;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ready!");
        using (Game game = new Game(800, 600, "Programación Grafica - OpenGL - OpenTk"))
        {
            game.Run();
        }
    }
}