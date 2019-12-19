using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWorkshop.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    { 
        // GET api/<controller>
        [HttpGet]
        public List<Customer> Get()
        {
            return GetAllCustomers();
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            return GetAllCustomers().Where(customer => customer.CustomerId == id).FirstOrDefault();
        }

        private static List<Customer> GetAllCustomers() => new List<Customer>()
            {
                new Customer
                {
                    CustomerId = 1,
                    Name = "Isadora Jarr"
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Ben Slackin"
                },
                new Customer
                {
                    CustomerId = 3,
                    Name = "Doo Fuss"
                },
                new Customer
                {
                    CustomerId = 4,
                    Name = "Hugh Jass"
                },
                new Customer
                {
                    CustomerId = 5,
                    Name = "Donatella Nawan"
                },
                new Customer
                {
                    CustomerId = 6,
                    Name = "Pykop Andropov"
                }
            };
    }
}
