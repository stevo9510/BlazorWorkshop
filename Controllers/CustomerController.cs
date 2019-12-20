using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWorkshop.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private List<Customer> Customers;
        private string customerDataFile = "";
        public CustomerController()
        {
            LoadData();
        }

        // GET api/<controller>
        [HttpGet]
        public List<Customer> Get()
        {
            return Customers;
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return Customers.Where(customer => customer.CustomerId == id).FirstOrDefault();
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            Customers.Add(customer);
            SaveData();
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            int indexOfCustomer = Customers.FindIndex(c => c.CustomerId == id);
            if (indexOfCustomer > -1)
            {
                Customers[indexOfCustomer] = customer;
                SaveData();
            }
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customerToRemove = Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            if(customerToRemove != null)
            {
                Customers.Remove(customerToRemove);
                SaveData();
            }
        }

        private void LoadData()
        {
            customerDataFile = Environment.CurrentDirectory + @"\customers.json";
            if (!System.IO.File.Exists(customerDataFile))
            {
                PopulateInitialCustomers();
                SaveData();
            }
            else
            {
                var json = System.IO.File.ReadAllText(customerDataFile);
                Customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }

        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(Customers);
            System.IO.File.WriteAllText(customerDataFile, json);
        }

        private void PopulateInitialCustomers()
        {
            if (Customers == null)
            {
                Customers = new List<Customer>(){
                    new Customer
                    {
                        CustomerId = 1,
                        Name = "Isadora Jarr",
                        Email = "isadora@jarr.com"

                    },
                    new Customer
                    {
                        CustomerId = 2,
                        Name = "Ben Slackin",
                        Email = "ben@slackin.com",
                    },
                    new Customer
                    {
                        CustomerId = 3,
                        Name = "Doo Fuss",
                        Email = "doo@fuss.com",
                    },
                    new Customer
                    {
                        CustomerId = 4,
                        Name = "Hugh Jass",
                        Email = "hugh@jass.com",
                    },
                    new Customer
                    {
                        CustomerId = 5,
                        Name = "Donatella Nawan",
                        Email = "donatella@nawan.com"
                    },
                    new Customer
                    {
                        CustomerId = 6,
                        Name = "Pykop Andropov",
                        Email = "pykop@andropov.com"
                    }
                };
            }
        }

    }
}
