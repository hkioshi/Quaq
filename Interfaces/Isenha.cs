namespace Quaq.Interfaces;
public interface IRepositorySenha
{
    void Salvar(string conta, string senha);
    string? Obter(string conta);
    void Remover(string conta);
}
