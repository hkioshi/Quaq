using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Quaq.Services.Diversao
{
    public class AdviceService
    {
        
        public static async Task GetAdvice()
        {
            HttpClient httpClient = new();

            AdviceResponse? json = await httpClient.GetFromJsonAsync<AdviceResponse>(
                "https://api.adviceslip.com/advice");

            Console.WriteLine(json?.slip.advice);
        }


    
    }

    public class AdviceResponse
    {
        public Advice slip { get; set; } = null!;
    }

    public class Advice
    {
        public int id { get; set; }
        public string advice { get; set; } = "";
    }
}