using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Internet;

namespace Quaq.Commands;

public class NavegacaoCommand : IComando
{
    public Command Get()
    {
        var navCmd = new Command("nav", "Navegar na Internet");

        var urlArg = new Argument<string?>("url")
        {
            Description = "URL para pesquisar",
            DefaultValueFactory = _ => null
        };

        var anonOp = new Option<bool>("-a", "--anon")
        {
            Description = "Modo anônimo"
        };

        navCmd.Add(urlArg);
        navCmd.Add(anonOp);

        navCmd.SetAction(pr =>
        {
            var url = pr.GetValue(urlArg);
            var anon = pr.GetValue(anonOp);

            if (anon)
            {
                if (url is null)
                    NavegacaoService.NavegarAnnon();
                else
                    NavegacaoService.NavegarAnnon(url);

                return;
            }

            if (url is null)
                NavegacaoService.Navegar();
            else
                NavegacaoService.Navegar(url);
        });

        return navCmd;
    }
}
