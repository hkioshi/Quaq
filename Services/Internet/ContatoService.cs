using Quaq.Data;
using Quaq.Repository;
using Quaq.Services.Sistema;
namespace Quaq.Services.Internet;
public class ContatoService
{
    static ContatoRepositorio service = new("contatos.json");

    public static Infos? BuscarContato(string nome)=> 
        service.BuscarContato(nome); 

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
        UiService.AvisoUi("email adicionado");
    
    }

    public static void DefinirTelefone(string v1, string v2)
    {
        var infos = service.BuscarContato(v1) ?? new Infos() ;
        infos.Telefone = v2;
        service.SalvarJsonContato(v1,infos);
        UiService.AvisoUi("telefone adicionado");

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
    public static void DeletarContato(string nome)
    {
        var contatos = service.BuscarTodosContatos();
        if(contatos.ContainsKey(nome))
        {
            UiService.AvisoUi("contato encontrado, quer mesmo deletar (y/n)");
            ConsoleKeyInfo tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.Y)
            {
                contatos.Remove(nome);
                UiService.AvisoUi("\nDeletado com sucesso");
            }
            else
            {
                UiService.AvisoUi("\nCancelado.");
            }
            
            

        }
        service.SalvarJsonContato(contatos);
    }
}

