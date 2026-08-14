using Quaq.Services.Sistema;
namespace Quaq.Services.Diversao;
public class DadosService
{
    public static void RolarDado(int lados) =>
        UiService.LinhaUi(
            "Dados",
            new Random()
                .Next(1,lados+1)
                .ToString());
}
