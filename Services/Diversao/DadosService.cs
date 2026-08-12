using Quaq.Services.Sistema;

namespace Quaq.Services.Diversao;
public class DadosService
{
    public static void RolarDado(int lados)
    {
        Random random = new();
        UiService.LinhaUi("Dados",random.Next(1,lados+1).ToString());
    }
}
