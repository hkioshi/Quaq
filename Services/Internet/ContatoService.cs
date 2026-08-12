using Quaq.Data;
using Quaq.Repository;
using Quaq.Services.Sistema;
namespace Quaq.Services.Internet;
public class ContatoService
{
    ContatoRepositorio service = new("contatos.json");

    public Infos? BuscarContato(string nome)=> 
        service.BuscarContato(nome); 

    public void DefinirEmail(string v1, string v2)
    {
        if (!EmailService.ValidarEmail(v2))
        {
            UiService.ErroUi("Email não valido");
            return;
        }
        var infos = service.BuscarContato(v1) ?? new Infos() ;
        infos.Email = v2;
        service.SalvarJsonContato(v1,infos);
        UiService.AvisoUi("email adicionado");
    
    }

    public void DefinirTelefone(string v1, string v2)
    {
        var infos = service.BuscarContato(v1) ?? new Infos() ;
        infos.Telefone = v2;
        service.SalvarJsonContato(v1,infos);
        UiService.AvisoUi("telefone adicionado");

    }

    public void Exibir()
    {
        UiService.LinhaUi("Contatos");

        foreach(var c in service.BuscarTodosContatos())
            UiService.ListaUi($"{c.Key}",[$"- Email - {c.Value.Email ?? "N/A"}",$"- Telefone - {c.Value.Telefone ?? "N/A"}"]);
    }
    public void Exibir(string nome)
    {
        var pessoa = service.BuscarContato(nome) ?? new Infos();
        UiService.ListaUi($"{nome}",[$"- Email - {pessoa.Email ?? "N/A"}",$"- Telefone - {pessoa.Telefone ?? "N/A"}"]);
    }
    public void DeletarContato(string nome)
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

