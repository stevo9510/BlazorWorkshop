using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWorkshop.Data
{
    public class CustomerService
    {
        private const string BaseURL = "https://localhost:44313/";

        public static async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                using(var httpClient = new HttpClient())
                {
                    var uri = new Uri($"{BaseURL}api/customer");
                    string json = await httpClient.GetStringAsync(uri);
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                    return customers;
                }
            }
            catch
            {
                return new List<Customer>();
            }
        }

        public static async Task<Customer> GetCustomerAsync(int customerId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var uri = new Uri($"{BaseURL}api/customer/{customerId}");
                    string json = await httpClient.GetStringAsync(uri);
                    var customer = JsonConvert.DeserializeObject<Customer>(json);
                    return customer;
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task AddCustomer(Customer customer)
        {
            using(var http = new HttpClient())
            {
                var uri = new Uri($"{BaseURL}api/customer");
                string jsonBody = JsonConvert.SerializeObject(customer);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                await http.PostAsync(uri, content);
            }
        }
    }
}
