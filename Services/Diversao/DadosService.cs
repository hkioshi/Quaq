namespace Quaq.Services.Diversao;
public class DadosService
{
    public static void RolarDado(int lados)
    {
        Random random = new();
        Console.WriteLine(random.Next(1,lados+1));
    }
}
