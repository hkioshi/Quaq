namespace Quaq.Repository;

public class DiretorioRepository 
{
    string pastaPrincipal = Path.Combine(
    Environment.GetFolderPath(
        Environment.SpecialFolder.UserProfile),
    "source",
    "repos"
    );
        

    public DiretorioRepository() =>
        Directory.CreateDirectory(pastaPrincipal);

    public List<string> ListarRepositorios() =>
        Directory.GetDirectories(pastaPrincipal).ToList();

    public string NovaPasta(string dir)
    {
        var directory = Path.Combine(pastaPrincipal,dir);
        if(!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        return directory;
    }

    public string AcharPasta(string opcao) =>
        Path.Combine(pastaPrincipal,opcao);

}
