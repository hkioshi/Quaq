using Quaq.Repository;
using Quaq.Services.Internet;

namespace Quaq.Services.Sistema;

public class ConfigService
{
   
    static private ConfigRepository config = new();
    
    public static void DefinirNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
           UiService.ErroUi("Nome inválido");
            return;
        }
        config.DefinirNome(nome);
        UiService.OkUi("Nome salvo!");

    }
    public static void ExibirNome()
    {
        var nome = config.ExibirNome();
        if(nome is null)
        {
            UiService.ErroUi("Nome não registrado.");
            return;
        }

        UiService.LinhaUi("Nome",$"O seu nome é {nome}");
    }
    public static void DefinirEmail(string email)
    {
     
        if(email is null)
        {
            UiService.ErroUi("Email vazio");
            return;
        }
        if(!EmailService.ValidarEmail(email))
        {
            UiService.ErroUi("Formato de email não valido");
            return;
        }
        SenhaRepository repos = new();

        string? emailAntigo = config.ExibirEmail();
        if(emailAntigo is null)
        {
            config.DefinirEmail(email);
            UiService.OkUi("Email salvo!");
            return;
        }

        string? senha = repos.ExibirSenha(emailAntigo);
        if(senha is null)
        {
            config.DefinirEmail(email);
            UiService.OkUi("Email salvo!");
            return;
        }

        config.DefinirEmail(email);
        repos.RemoverSenha(emailAntigo);
        repos.SalvarSenha(email,senha);
        UiService.OkUi("Email salvo!");
        
    }

    public static void ExibirEmail()
    {
        var email = config.ExibirEmail();
        if(email is null)
        {
            UiService.AvisoUi("Email não registrado.");
            return;
        }

        UiService.LinhaUi("Email",$"O seu email é {email}");
    }


    internal static void ExibirSenha()
    {
        SenhaRepository repos = new();
        var email = config.ExibirEmail();
        if(email is null)
        {
            UiService.ErroUi("Email não Definido");
            return;
        }
        var senha = repos.ExibirSenha(email);
        if(senha is null)
        {
            UiService.ErroUi("Senha não Definida");
            return;
        }
        UiService.LinhaUi("Senha",senha);
    }

    internal static void DefinirSenha(string senha)
    {
        SenhaRepository repos = new();
        var email = config.ExibirEmail();
        if(email is null)
        {
            UiService.ErroUi("Email não Definido");
            return;
        }
        repos.SalvarSenha(email, senha);
        UiService.OkUi("Senha salva!");

    }

    internal static void RemoverSenha()
    {
        SenhaRepository repos = new();
        var email = config.ExibirEmail();
        if(email is null)
        {
            UiService.ErroUi("Email não Definido");
            return;
        }
        repos.RemoverSenha(email);    
        UiService.OkUi("Email Removido");

    }
}
