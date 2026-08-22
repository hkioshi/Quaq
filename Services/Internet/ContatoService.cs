using Quaq.Data;
using Quaq.Repository;
using Quaq.Services.Sistema;
using Spectre.Console;
namespace Quaq.Services.Internet;
public class ContatoService
{
    static ContatoRepositorio service = new("contatos.json");

    public static Infos? BuscarContato(string nome)=> 
        service.BuscarContato(nome); 



    public static void Definir(string nome)
    {        
        var opcao = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[bold]Selecione uma playlist:[/]")
            .AddChoices("Email","Telefone"));
        
        if (opcao == "Email")
        {
            string? email = AnsiConsole.Prompt(
                new TextPrompt<string?>("Digite o email:")
                    .AllowEmpty()
            );

            if (email is null)
                return;

            DefinirEmail(nome, email);
            return;
        }

        string? telefone = AnsiConsole.Prompt(
                new TextPrompt<string?>("Digite o telefone:")
                    .AllowEmpty()
            );

        if (telefone is null)
            return;

        DefinirTelefone(nome, telefone);
        return;

    }
    public static void DefinirEmail(string nome, string email)
    {
        if (!EmailService.ValidarEmail(email))
        {
            UiService.ErroUi("Email não valido");
            return;
        }
        var infos = service.BuscarContato(nome) ?? new Infos() ;
        infos.Email = email;
        service.SalvarJsonContato(nome,infos);
        UiService.OkUi("email adicionado");
    
    }

    public static void DefinirTelefone(string v1, string v2)
    {
        var infos = service.BuscarContato(v1) ?? new Infos() ;
        infos.Telefone = v2;
        service.SalvarJsonContato(v1,infos);
        UiService.OkUi("telefone adicionado");

    }

    public static void ExibirTodosContatos()
    {
        UiService.LinhaUi("Contatos");

        foreach(var c in service.BuscarTodosContatos())
            UiService.ListaUi($"{c.Key}",[$"- Email - {c.Value.Email ?? "N/A"}",$"- Telefone - {c.Value.Telefone ?? "N/A"}"]);
    }
    public static void ExibirContato(string nome)
    {
        var pessoa = service.BuscarContato(nome) ?? new Infos();
        UiService.ListaUi($"{nome}",[$"- Email - {pessoa.Email ?? "N/A"}",$"- Telefone - {pessoa.Telefone ?? "N/A"}"]);
    }
    public static void DeletarContato()
    {
        var todos = service.BuscarTodosContatos();
        var contatos = todos.Select(x => x.Key);
        var opcao = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[bold]Selecione uma playlist:[/]")
            .AddChoices(contatos));
        if(todos.ContainsKey(opcao))
        {
            UiService.AvisoUi("contato encontrado, quer mesmo deletar (y/n)");
            ConsoleKeyInfo tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.Y)
            {
                todos.Remove(opcao);
                UiService.OkUi("\nDeletado com sucesso");
            }
            else
                UiService.OkUi("\nCancelado.");
        }
        service.SalvarJsonContato(todos);
    }
}

