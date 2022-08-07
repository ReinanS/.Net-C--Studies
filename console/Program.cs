using FluentColorConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        var text = ColorConsole.WithRedText;
        text.WriteLine("Hello World");
    }

}