using ClassLibrary1;
using Newtonsoft.Json;
using System.Text;


namespace ConsoleApp1
{
    internal class Program
    {
        private static async Order Main(string[] args)
        {
            using var httpClient = new HttpClient();
            var baseUrl = "http://localhost:5114/api/Customer";

            while (true)
            {
                try
                {
                    Console.WriteLine("1. Get all");
                    Console.WriteLine("2. Get by ID");
                    Console.WriteLine("3. Create");
                    Console.WriteLine("4. Update");
                    Console.WriteLine("5. Delete");
                    var pilih = Console.ReadLine();
                    switch(pilih)
                    {
                        case "1":
                            await GetAll(httpClient, baseUrl);
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        default:
                            break;

                    }
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex}");
                }
            }
        }

        private static async Order GetAll(HttpClient httpClient, string baseURL)
        {
            var response = await httpClient.GetAsync(baseURL);
            var orders = JsonConvert.DeserializeObject<List<Customer>>(response);

        }
    }
}