using System.Text.Json;
using Quaq.Data;
using Quaq.Services.Sistema;

namespace Quaq.Repository;

public class AppRepository : Repositorio
{
    public AppRepository(string caminho): base(caminho)
    {}

    public void SalvarJsonApp(string nome, Comando comando)
    {   
        var json = JsonSerializer.Deserialize<Dictionary<string, Comando>>(AbrirJson())
        ?? new Dictionary<string, Comando>();

        json[nome] = comando;

        string texto = JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }

    internal Comando? ExibirComando(string nome)
    {
        var json = JsonSerializer.Deserialize<Dictionary<string, Comando>>(AbrirJson())
        ?? new Dictionary<string, Comando>();

        if(json.ContainsKey(nome))
            return json[nome];

        UiService.ErroUi("Nenhum app salvo com este nome.");
        return null;
    }
    public Dictionary<string,Comando> BuscarTodosApps() =>
        JsonSerializer.Deserialize<Dictionary<string,Comando>>(AbrirJson()) 
            ?? new Dictionary<string,Comando>();

    internal void SalvarJsonContato(Dictionary<string, Comando> apps)
    {
        string texto = JsonSerializer.Serialize(apps, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }
}
