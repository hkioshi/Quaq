namespace Quaq.Services.Sistema;
public class LogService
{
    public static void Logs() =>
        Console.WriteLine(
            File.ReadAllText( 
                Path.Combine( 
                    AppContext.BaseDirectory, 
                    "devlog.txt")));
}

