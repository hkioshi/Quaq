namespace Quaq.Data;

public class Comando
{
    public string Raiz { get; set; } = "";
    public string? Args { get; set; } = "";

    public Comando()
    {
    }
    public Comando(string r, string? c)
    {
        Raiz =r;
        Args = c;
    }
}
