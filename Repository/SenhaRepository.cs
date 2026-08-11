using GnomeStack.Standard;

namespace Quaq.Repository;

public class SenhaRepository
{
    private const string Servico = "quaq";

    public void SalvarSenha(string email, string senha)
    {
        OsSecretVault.SetSecret(
            Servico,
            email,
            senha);
    }

    public string? ExibirSenha(string email)
    {
        return OsSecretVault.GetSecret(
            Servico,
            email);
    }

    public void RemoverSenha(string email)
    {
        OsSecretVault.DeleteSecret(
            Servico,
            email);
    }
}