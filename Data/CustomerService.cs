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
                using (var httpClient = new HttpClient())
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

        public static async Task AddCustomerAsync(Customer customer)
        {
            using (var http = new HttpClient())
            {
                var uri = new Uri($"{BaseURL}api/customer");
                string jsonBody = JsonConvert.SerializeObject(customer);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                await http.PostAsync(uri, content);
            }
        }

        public static async Task UpdateCustomerAsync(Customer customer)
        {
            using(var http = new HttpClient())
            {
                var uri = new Uri($"{BaseURL}api/customer/{customer.CustomerId}");
                string jsonBody = JsonConvert.SerializeObject(customer);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await http.PutAsync(uri, content);
                if(responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Customer was not updated");
                }
            }
        }

        public static async Task DeleteCustomerAsync(int customerId)
        {
            using (var http = new HttpClient())
            {
                var uri = new Uri($"{BaseURL}api/customer/{customerId}");
                HttpResponseMessage responseMessage = await http.DeleteAsync(uri);
                if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Customer was not deleted");
                }
            }
        }
    }
}
