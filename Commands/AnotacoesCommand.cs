using System.CommandLine;
using Quaq.Commands.Interfaces;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;

public class AnotacoesCommand: IComando
{
    public Command Get()
    {
        var AnotarOP = new Option<string>("-a", "--anotar");
        var ListaOp = new  Option<bool>("ls", "lista");
        var AnotacaoCmd = new Command("anotacao", "Anotações")
        {
            ListaOp,
            AnotarOP
        };
        
        AnotacaoCmd.SetAction(pr =>
        {
            var lista = pr.GetValue(ListaOp);
            var anotar = pr.GetValue(AnotarOP);

            if(anotar is not null && lista)
            {
                Console.WriteLine("Deve ter apenas um destino");
                return;
            }

            if(lista )
            {
               AnotacaoService.Listar();
               return;
            }
            

            if(anotar is not null)
            {
                AnotacaoService.IniciarAnotacao(anotar);
               return;
            }
        });

        return AnotacaoCmd;
    }
}