namespace Quaq.Data;

public class Tarefa
{
    public string Nome { get; set; } = "";
    public DateTime? data  { get; set; }
    public string? descricao  { get; set; }
    public string status {get; set;} = "Incompleto";


}
