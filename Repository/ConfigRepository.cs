using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Quaq.Data;

namespace Quaq.Repository;

public class ConfigRepository
{
 
    private string PastaConfig = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        ".config","quaq");

    private string arquivo = string.Empty;


    public ConfigRepository()
    {
        if(!Directory.Exists(PastaConfig))
        {
            Directory.CreateDirectory(PastaConfig);
        }

        arquivo = Path.Combine(PastaConfig, "config.json");   

        if(!Path.Exists(arquivo))
        {
            File.WriteAllText(arquivo,
            """
            {
                "nome": "",
                "email": ""
            }
            """);
        }

    }

    private Config AbrirJson() =>
        JsonSerializer.Deserialize<Config>(File.ReadAllText(arquivo))
        ?? new Config();

    private void SalvarJson(Config config) =>
        File.WriteAllText(arquivo, JsonSerializer.Serialize(config, new JsonSerializerOptions
            {
                WriteIndented = true
            }));

    public string? ExibirNome()
    {
        var json = AbrirJson();
        return json.Nome == "" ?
            null:
            json.Nome;

    }
    
    
    internal  void DefinirEmail(string email)
    {
        var json = AbrirJson();
        json.Email = email;
        SalvarJson(json);
    }

    internal  void DefinirNome(string nome)
    {
        var json = AbrirJson();
        json.Nome = nome;
        SalvarJson(json);
    }

    internal string? ExibirEmail()
    {
        var json = AbrirJson();
        return json.Email == "" ?
            null:
            json.Email;
   
    }
}
