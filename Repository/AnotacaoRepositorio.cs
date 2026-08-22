using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Quaq.Data;
using Quaq.Services.Sistema;

namespace Quaq.Repository;

public class AnotacaoRepositorio:Repositorio
{
    public AnotacaoRepositorio(string caminho): base(caminho)
    {}
    public List<string> BuscarTodosCadernos()
    {
        var json = JsonSerializer.Deserialize<Dictionary<string,List<string>>>(AbrirJson()) 
            ?? new Dictionary<string,List<string>>();

        List<string> lista = [];
        foreach (var item in json)
        {
            lista.Add(item.Key);
        }
        return lista;
    }
        
    
    public List<string>? BuscarCaderno(string nome)
    {
        var json = JsonSerializer.Deserialize<Dictionary<string,List<string>>>(AbrirJson()) 
            ?? new Dictionary<string,List<string>>();
        if(!json.ContainsKey(nome))
            return null;
        
        return json[nome];
    }

    public void SalvarAnotacoes(string nome, List<string> anotacoes)
    {
    var json = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(AbrirJson())
        ?? new Dictionary<string, List<string>>();

        if(!json.ContainsKey(nome))
            json.Add(nome, []);
        foreach(var i in anotacoes)
            json[nome].Add(i);
        
        string texto = JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }

    internal void Remover(string opcao)
    {
        var projs = JsonSerializer.Deserialize<Dictionary<string,List<string>>>(AbrirJson()) 
            ?? new Dictionary<string,List<string>>();
            if(projs.ContainsKey(opcao))
            {
                UiService.OkUi("Caderno encontrado, quer mesmo deletar (y/n)");
                ConsoleKeyInfo tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Y)
                {
                    projs.Remove(opcao);
                    UiService.OkUi("\nDeletado com sucesso");
                }
                else
                    UiService.OkUi("\nCancelado.");
                
            }
            string texto = JsonSerializer.Serialize(projs, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(caminho, texto);
    }
}
