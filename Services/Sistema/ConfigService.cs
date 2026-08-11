using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Console.WriteLine("Nome inválido");
            return;
        }
        config.DefinirNome(nome);
        Console.WriteLine("Nome salvo!");

    }
    public static void ExibirNome()
    {
        var nome = config.ExibirNome();
        if(nome is null)
        {
            Console.WriteLine("Nome não registrado.");
            return;
        }

        Console.WriteLine($"O seu nome é {nome}");
    }
    public static void DefinirEmail(string email)
    {
     
        if(email is null)
        {
            Console.WriteLine("Email vazio");
            return;
        }
        if(!EmailService.ValidarEmail(email))
        {
            Console.WriteLine("Formato de email não valido");
            return;
        }
        SenhaRepository repos = new();

        string? emailAntigo = config.ExibirEmail();
        if(emailAntigo is null)
        {
            config.DefinirEmail(email);
            Console.WriteLine("Email salvo!");
            return;
        }

        string? senha = repos.ExibirSenha(emailAntigo);
        if(senha is null)
        {
            config.DefinirEmail(email);
            Console.WriteLine("Email salvo!");
            return;
        }

        config.DefinirEmail(email);
        repos.RemoverSenha(emailAntigo);
        repos.SalvarSenha(email,senha);
        Console.WriteLine("Email salvo!");
        
    }

    public static void ExibirEmail()
    {
        var email = config.ExibirEmail();
        if(email is null)
        {
            Console.WriteLine("Email não registrado.");
            return;
        }

        Console.WriteLine($"O seu email é {email}");
    }


    internal static void ExibirSenha()
    {
        SenhaRepository repos = new();
        var email = config.ExibirEmail();
        if(email is null)
        {
            Console.WriteLine("Email não Definido");
            return;
        }
        var senha = repos.ExibirSenha(email);
        if(senha is null)
        {
            Console.WriteLine("Senha não Definida");
            return;
        }
        Console.WriteLine(senha);
    }

    internal static void DefinirSenha(string senha)
    {
        SenhaRepository repos = new();
        var email = config.ExibirEmail();
        if(email is null)
        {
            Console.WriteLine("Email não Definido");
            return;
        }
        repos.SalvarSenha(email, senha);

    }

    internal static void RemoverSenha()
    {
        SenhaRepository repos = new();
        var email = config.ExibirEmail();
        if(email is null)
        {
            Console.WriteLine("Email não Definido");
            return;
        }
        repos.RemoverSenha(email);    

    }
}
