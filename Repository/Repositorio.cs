namespace Quaq.Repository;
public class Repositorio
{
    string pasta = Path.Combine(
    Environment.GetFolderPath(
        Environment.SpecialFolder.UserProfile),
    ".quaq");

    public string caminho { get; set; }
    public Repositorio(string c)
    {
        Directory.CreateDirectory(pasta);

        caminho = Path.Combine(
            pasta,
            c);
    }
        
    public string AbrirJson()
    {
        if (!File.Exists(caminho)) File.WriteAllText(caminho, "{}");
        return File.ReadAllText(caminho);
    }

}
