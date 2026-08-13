using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;
using Quaq.Services.Sistema;

namespace Quaq.Commands;
public class NovoCommand: IComando
{
    private static Command CriarNovoTesteCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do Projeto."
        };
        var cmd = new Command("teste", "Cria projeto teste")
        {
            nomeArg
        };
        var webApiOp = new Option<bool>("-api")
        {
            Description = "Cria Projeto WebApi"
        };
        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            var api = pr.GetValue(webApiOp);

            if(nome is null)
            {
                UiService.ErroUi("Nome deve ser informado");
                return;
            }

            if(api)
            {
                NovoService.CriarNovo(nome,"webapi","Projetos_Testes");
                return;
            }

            NovoService.CriarNovo(nome,"console","Projetos_Testes");
        });
        return cmd;
    }
    private static Command CriarNovoPessoalCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do Projeto."
        };
        var cmd = new Command("teste", "Cria projeto pessoal")
        {
            nomeArg
        };
        var webApiOp = new Option<bool>("-api")
        {
            Description = "Cria Projeto WebApi"
        };
        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            var api = pr.GetValue(webApiOp);

            if(nome is null)
            {
                UiService.ErroUi("Nome deve ser informado");
                return;
            }

            if(api)
            {
                NovoService.CriarNovo(nome,"webapi","Projetos_Pessoais");
                return;
            }

            NovoService.CriarNovo(nome,"console","Projetos_Pessoais");
        });
        return cmd;
    }
    public Command Get() =>
        new Command("novo", "Novo Projeto c#")
        {
            CriarNovoPessoalCommand(),
            CriarNovoTesteCommand()
        };
    


}