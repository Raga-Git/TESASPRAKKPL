using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly string FilePath = "D://Tel U//Semester 4//KPL//TesKPLASPRAK//ConsoleApp1//orders.json";
        private static List<Customer> Customers = new List<Customer>();

        public CustomerController()
        {
            try
            {
                LoadProjects();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error data : {ex.Message}");
            }
        }

        private void LoadProjects()
        {
            if (System.IO.File.Exists(FilePath))
            {

                string json = System.IO.File.ReadAllText(FilePath);
                Customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }

        }

        private static void SaveProjects()
        {
            string json = JsonConvert.SerializeObject(Customers, Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, json);
        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            if (Customers.Count == 0)
            {
                return Ok("Belum ada data");
            }
            return Ok(Customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = Customers.FirstOrDefault(p => p.Id == id);
            if (project == null) return NotFound("Customers not found.");
            return Ok(project);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] Customer Customer)
        {
            Customer.Id = Customers.Count + 1;
            Customers.Add(Customer);
            SaveProjects();
            return CreatedAtAction(nameof(GetProjectById), new { id = Customer.Id }, Customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, [FromBody] Customer updatedCustomer)
        {
            var customer = Customers.FirstOrDefault(p => p.Id == id);
            if (customer == null) return NotFound("Customer not found.");

            customer.Quantity = updatedCustomer.Quantity;
            customer.Total_price = updatedCustomer.Total_price;
            customer.Shipping_address = updatedCustomer.Shipping_address;
            customer.Status = updatedCustomer.Status;

            SaveProjects();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = Customers.FirstOrDefault(p => p.Id == id);
            if (project == null) return NotFound("Customer not found.");

            Customers.Remove(project);
            SaveProjects();
            return NoContent();
        }



    }
}
