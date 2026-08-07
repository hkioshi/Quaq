using System.Net;
using System.Net.Mail;
using DotNetEnv;
using Quaq.Data;
namespace Quaq.Services.Internet;
public class NullEmailException : Exception;
public class NullContatoException : Exception;

public class EmailService
{
    public static void EnviarEmail(string Email, string Assunto, string Corpo )
    {
        try
        {
            MailMessage mail = new MailMessage();
            Env.Load();
            string? senha = Environment.GetEnvironmentVariable("SENHAEMAIL");
            string? email = Environment.GetEnvironmentVariable("EMAIL");
                
            mail.From = new MailAddress(email!);
            mail.To.Add(Email);
            mail.Subject = Assunto;
            mail.Body = Corpo;
            mail.IsBodyHtml = false; // Opcional: para HTML

            // 2. Configurar o cliente SMTP
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {

                
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(email,senha );
                // 3. Enviar
                    smtp.Send(mail);
                    Console.WriteLine("E-mail enviado com sucesso!");
            
            }
        }
        
        catch (FormatException)
        {
            Console.WriteLine("O email não está no formato correto.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao enviar: " + ex.Message);
        }
    }

    public static bool ValidarEmail(string v)
    {
        string[] finaisEmail =
        {
            "@gmail.com",
            "@hotmail.com",
            "@outlook.com",
            "@yahoo.com",
            "@icloud.com"
        };

        foreach(var i in finaisEmail)
        {
            if(v.Contains(i)) return true;
        }
        return false;
    }

    public static void EnviarEmailComContato(string nome, string Assunto, string Corpo)
    {
        try
        {
            MailMessage mail = new MailMessage();
            ContatoService service = new();
            Infos? contato = service.BuscarContato(nome);
            if(contato is null)
                throw new NullContatoException();
            if(contato.Email is null)
                throw new NullEmailException();
            Env.Load();

            string? senha = Environment.GetEnvironmentVariable("SENHAEMAIL");
            string? email = Environment.GetEnvironmentVariable("EMAIL");
                
            mail.From = new MailAddress(email!);
            mail.To.Add(contato.Email);
            mail.Subject = Assunto;
            mail.Body = Corpo;
            mail.IsBodyHtml = false; // Opcional: para HTML

            // 2. Configurar o cliente SMTP
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(email,senha );
                // 3. Enviar
                    smtp.Send(mail);
                    Console.WriteLine("E-mail enviado com sucesso!");
            
            }
        }
        catch (NullEmailException)
        {
            Console.WriteLine("Este contato não possui email");
        }
        catch (NullContatoException)
        {
            Console.WriteLine("Este contato não esta registrado");
        }
        catch (FormatException)
        {
            Console.WriteLine("O email não está no formato correto.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao enviar: " + ex.Message);
        }
    }
}
