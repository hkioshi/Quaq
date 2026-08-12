using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;
using Quaq.Services.Sistema;

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
                UiService.ErroUi("Deve ter apenas um destino");
                return;
            }

            if(teste is not null)
            {
                if(api)
                {
                    NovoService.CriarNovo(teste,"webapi","Projetos_Testes");
                    return;
                }

                NovoService.CriarNovo(teste,"console","Projetos_Testes");
            }
            
            if(pessoal is not null)
            {
                if(api)
                {
                    NovoService.CriarNovo(pessoal,"webapi","Projetos_Pessoais");
                    return;

                }

                NovoService.CriarNovo(pessoal,"console","Projetos_Pessoais");
            }

        });

        return NovoCmd;
    }


}