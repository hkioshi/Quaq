using Quaq.Data;
using Quaq.Repository;
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
            Console.WriteLine("Email não valido");
            return;
        }
        var infos = service.BuscarContato(v1) ?? new Infos() ;
        infos.Email = v2;
        service.SalvarJsonContato(v1,infos);
        Console.WriteLine("email adicionado");
    
    }

    public void DefinirTelefone(string v1, string v2)
    {
        var infos = service.BuscarContato(v1) ?? new Infos() ;
        infos.Telefone = v2;
        service.SalvarJsonContato(v1,infos);
        Console.WriteLine("telefone adicionado");

    }

    public void Exibir()
    {
        foreach(var c in service.BuscarTodosContatos())
            Console.WriteLine($"{c.Key}\n- Email - {c.Value.Email ?? "N/A"}\n- Telefone - {c.Value.Telefone ?? "N/A"}\n");
    }
    public void Exibir(string nome)
    {
        var pessoa = service.BuscarContato(nome) ?? new Infos();
        Console.WriteLine($"{nome}\n- Email - {pessoa.Email ?? "N/A"}\n- Telefone - {pessoa.Telefone ?? "N/A"}\n");
    }
    public void DeletarContato(string nome)
    {
        var contatos = service.BuscarTodosContatos();
        if(contatos.ContainsKey(nome))
        {
            Console.WriteLine("contato encontrado, quer mesmo deletar (y/n)");
            ConsoleKeyInfo tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.Y)
            {
                contatos.Remove(nome);
                Console.WriteLine("\nDeletado com sucesso");
            }
            else
            {
                Console.WriteLine("\nCancelado.");
            }
            
            

        }
        service.SalvarJsonContato(contatos);
    }
}

