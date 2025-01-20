using ClassLibrary1;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;



namespace ConsoleApp1
{
    internal class Program
    {
        private static async void Main(string[] args)
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
                    switch (pilih)
                    {
                        case "1":
                            var responseget = await httpClient.GetStringAsync(baseUrl);
                            var customersget = JsonConvert.DeserializeObject<List<Customer>>(responseget);
                            foreach (var customer in customersget)
                            {
                                Console.WriteLine($"ID              : {customer.Id}");
                                Console.WriteLine($"Customer Name   : {customer.Customer_name}");
                                Console.WriteLine($"Product Name    : {customer.Product_name}");
                                Console.WriteLine($"Quantity        : {customer.Quantity}");
                                Console.WriteLine($"Total Price     : {customer.Total_price}");
                                Console.WriteLine($"Order Date      : {customer.Order_date}");
                                Console.WriteLine($"Shipping Address: {customer.Shipping_address}");
                            }
                            break;
                        case "2":
                            var id = Console.ReadLine();
                            var responseid = await httpClient.GetStringAsync($"{baseUrl}/{id}");
                            var customersid = JsonConvert.DeserializeObject<Customer>(responseid);
                            Console.WriteLine($"ID              : {customersid.Id}");
                            Console.WriteLine($"Customer Name   : {customersid.Customer_name}");
                            Console.WriteLine($"Product Name    : {customersid.Product_name}");
                            Console.WriteLine($"Quantity        : {customersid.Quantity}");
                            Console.WriteLine($"Total Price     : {customersid.Total_price}");
                            Console.WriteLine($"Order Date      : {customersid.Order_date}");
                            Console.WriteLine($"Shipping Address: {customersid.Shipping_address}");
                            break;
                        case "3":
                            Console.Write("Enter Customer Name: ");
                            var name = Console.ReadLine();

                            Console.Write("Enter Product Name: ");
                            var product = Console.ReadLine();

                            Console.Write("Enter Quantity: ");
                            var quantity = Console.ReadLine();

                            Console.Write("Enter Total Price: ");
                            var price = Console.ReadLine();

                            Console.Write("Enter Order date Name: ");
                            var date = Console.ReadLine();

                            Console.Write("Enter Shipping address: ");
                            var address = Console.ReadLine();

                            Console.Write("Enter Status: ");
                            var status = Console.ReadLine();


                            var newProject = new { Customer_name = name, Product_name = product, Quantity = quantity, Total_price = price, Order_date= date, Shipping_address = address, Status = status };
                            var projectJson = JsonConvert.SerializeObject(newProject);
                            var content = new StringContent(projectJson, Encoding.UTF8, "application/json");
                            var result = await httpClient.PostAsync(baseUrl, content);
                            break;
                        case "4":

                            break;
                        case "5":
                            break;
                        default:
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex}");
                }
            }
        }
    }
}