using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;
using Quaq.Services.Sistema;

namespace Quaq.Commands;
public class NovoCommand: IComando
{
    private static void CriarProjeto(
        string? nome, 
        string pasta, 
        bool api,
        bool py,
        bool rust)
    {
        if(nome is null)
            {
                UiService.ErroUi("Nome deve ser informado");
                return;
            }

            if(api)
            {
                NovoService.CriarNovo(nome,"webapi",pasta);
                return;
            }

            if(py)
            {
                NovoService.CriarNovoPy(nome,pasta);
                return;
            }
             if(rust)
            {
                NovoService.CriarNovoRust(nome,pasta);
                return;
            }
            NovoService.CriarNovo(nome,"console",pasta);
    }
    
    private static Command CriarNovoTesteCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do Projeto."
        };
        var webApiOp = new Option<bool>("-api")
        {
            Description = "Cria Projeto WebApi"
        };
        var pyOp = new Option<bool>("-py")
        {
            Description = "Cria Projeto py"
        };
        var rustOp = new Option<bool>("-rust")
        {
            Description = "Cria Projeto rust"
        };
        var cmd = new Command("teste", "Cria projeto teste")
        {
            nomeArg,
            webApiOp,
            pyOp,
            rustOp
        };
        
        cmd.SetAction(pr =>
            CriarProjeto(
                    pr.GetValue(nomeArg),
                    "Projetos_Testes",
                    pr.GetValue(webApiOp),
                    pr.GetValue(pyOp),
                    pr.GetValue(rustOp)));
        return cmd;
    }
    private static Command CriarNovoPessoalCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do Projeto."
        };
        var webApiOp = new Option<bool>("-api")
        {
            Description = "Cria Projeto WebApi"
        };
        var pyOp = new Option<bool>("-py")
        {
            Description = "Cria Projeto py"
        };
        var rustOp = new Option<bool>("-rust")
        {
            Description = "Cria Projeto rust"
        };
        var cmd = new Command("pessoal", "Cria projeto pessoal")
        {
            nomeArg,
            webApiOp,
            pyOp,
            rustOp
        };
        cmd.SetAction(pr =>
            CriarProjeto(
                pr.GetValue(nomeArg),
                "Projetos_Pessoais",
                pr.GetValue(webApiOp),
                pr.GetValue(pyOp),
                pr.GetValue(rustOp))
        );
        return cmd;
    }
    public Command Get() =>
        new Command("novo", "Novo Projeto")
        {
            CriarNovoPessoalCommand(),
            CriarNovoTesteCommand()
        };
    


}