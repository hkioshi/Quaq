using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;

namespace Quaq.Commands;
public class NovoCommand: IComando
{
    public Command Get()
    {
        var NovoCmd = new Command("novo", "Novo Projeto c#");

        var TesteOp = new Option<string>("-t","--teste","teste")
        {
            Description = "Cria Projeto Teste"
        };

        var PessoalOp = new Option<string>("-p", "--pessoal", "pessoal")
        {
            Description = "Cria Projeto pessoal"
        };

        var webApiOp = new Option<bool>("-api")
        {
            Description = "Cria Projeto WebApi"
        };
        NovoCmd.Add(PessoalOp);
        NovoCmd.Add(TesteOp);
        NovoCmd.Add(webApiOp);
        NovoCmd.SetAction(pr =>
        {
            var pessoal = pr.GetValue(PessoalOp);
            var teste = pr.GetValue(TesteOp);
            var api = pr.GetValue(webApiOp);

            if(teste is not null && pessoal is not null)
            {
                Console.WriteLine("Deve ter apenas um destino");
                return;
            }

            if(teste is not null)
            {
                if(api)
                {
                    NovoService.CriarNovoTesteApi(teste);
                    return;
                }

                NovoService.CriarNovoTesteTerminal(teste);
            }
            
            if(pessoal is not null)
            {
                if(api)
                {
                    NovoService.CriarNovoPessoalApi(pessoal);
                    return;

                }

                NovoService.CriarNovoPessoalTerminal(pessoal);
            }

        });

        return NovoCmd;
    }


}