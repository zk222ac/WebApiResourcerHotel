using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiResourcerHotel;

namespace WebAPIConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step no : 1 
            const string serverUrl = "http://localhost:16555";
            
            // Step no : 2
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.UseDefaultCredentials = true;
                using (var client = new  HttpClient())
                {
                    client.BaseAddress = new Uri(serverUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        var resp = client.GetAsync("api/Hotels").Result;
                        if (resp.IsSuccessStatusCode)
                        {
                            var hotels = resp.Content.ReadAsAsync<IList<Hotel>>().Result;
                            foreach (var hotel in hotels)
                            {
                                Console.WriteLine(hotel);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

             

            Console.ReadKey();

         }
    }
}
