using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Quaq.Data;

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


        anotacoes.ForEach(a => json[nome].Add(a));
        

        string texto = JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }



}
