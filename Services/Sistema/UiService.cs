using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quaq.Services.Sistema
{
    public class UiService
    {
        public static void LinhaUi(string titulo,string texto)
        {
            int tamanho = texto.Length + 2 - titulo.Length ;
            if(tamanho > 0)
            {
                Console.WriteLine($"┌{titulo}{new string('─', tamanho )}┐");
                Console.WriteLine($"│ {texto} │");
                Console.WriteLine($"└{new string('─', texto.Length + 2)}┘");
            }
            else
            {
                Console.WriteLine($"┌{titulo}{new string('─', 2 )}┐");
                Console.WriteLine($"│ {texto}{new string(' ', titulo.Length - texto.Length)} │");
                Console.WriteLine($"└{new string('─', titulo.Length + 2)}┘");
            }
            

        }

        public static void LinhaUi(string texto)
        {
                Console.WriteLine($"┌{new string('─', texto.Length + 2 )}┐");
                Console.WriteLine($"│ {texto} │");
                Console.WriteLine($"└{new string('─', texto.Length + 2)}┘");
        }

        public static void AvisoUi(string texto)
        {
            LinhaUi("Aviso",texto);
        }

        public static void ErroUi(string texto)
        {
            LinhaUi("Erro",texto);
        }

        internal static void ListaUi(string titulo, string[] linhas)
        {
            int maior = Math.Max(
                titulo.Length,
                linhas.Max(x => x.Length)
            );


            Console.WriteLine($"┌─{titulo}{new string('─', maior - titulo.Length + 1)}┐");

            foreach (var texto in linhas)
            {
                Console.WriteLine($"│ {texto}{new string(' ', maior - texto.Length)} │");
            }

            Console.WriteLine($"└{new string('─', maior + 2)}┘");
        }
    }
}