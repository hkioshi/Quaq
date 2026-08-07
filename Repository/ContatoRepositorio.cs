using System.Text.Json;
using Quaq.Data;

namespace Quaq.Repository;
public class ContatoRepositorio: Repositorio
{
    
    public ContatoRepositorio(string caminho): base(caminho)
    {}
    public Dictionary<string,Infos> BuscarTodosContatos() =>
        JsonSerializer.Deserialize<Dictionary<string,Infos>>(AbrirJson()) 
            ?? new Dictionary<string,Infos>();
    
    public Infos? BuscarContato(string nome)
    {
        var json = JsonSerializer.Deserialize<Dictionary<string,Infos>>(AbrirJson()) 
            ?? new Dictionary<string,Infos>();
        if(!json.ContainsKey(nome))
            return null;
        
        return json[nome];
    }

    public void SalvarJsonContato(string nome, Infos infos)
    {
       var json = JsonSerializer.Deserialize<Dictionary<string, Infos>>(AbrirJson())
           ?? new Dictionary<string, Infos>();

        json[nome] = infos;

        string texto = JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }
    public void SalvarJsonContato(Dictionary<string, Infos> json)
    {
     
        string texto = JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }


    
}