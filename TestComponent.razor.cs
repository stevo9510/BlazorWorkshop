using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWorkshop
{
    public class TestComponentCode : ComponentBase
    {
        [Parameter]
        public List<Customer> Customers { get; set; } = new List<Customer>();

        [Parameter]
        public Customer SelectedCustomer { get; set; }

        [Parameter]
        public EventCallback<Customer> CustomerSelectEvent { get; set; }

        [Parameter]
        public EventCallback<int> CustomerResetEvent { get; set; }

        [Parameter]
        public EventCallback<string> AddCustomerEvent { get; set; }

        [Parameter]
        public EventCallback<Customer> UpdateCustomerEvent { get; set; }

        [Parameter]
        public EventCallback<int> DeleteCustomerEvent { get; set; }

        protected string NewCustomerName { get; set; }

        protected async Task CustomerSelected(ChangeEventArgs args)
        {
            SelectedCustomer = Customers.Where(cust => cust.CustomerId.ToString() == args.Value.ToString()).First();
            await CustomerSelectEvent.InvokeAsync(SelectedCustomer);
        }

        protected async Task ResetButtonClicked()
        {
            await CustomerResetEvent.InvokeAsync(SelectedCustomer.CustomerId);
        }

        protected async Task AddButtonClicked()
        {
            await AddCustomerEvent.InvokeAsync(NewCustomerName);
            NewCustomerName = string.Empty;
        }

        protected async Task UpdateButtonClicked()
        {
            await UpdateCustomerEvent.InvokeAsync(SelectedCustomer);
        }

        protected async Task DeleteButtonClicked()
        {
            await DeleteCustomerEvent.InvokeAsync(SelectedCustomer.CustomerId);
            SelectedCustomer = null;
        }
    }
}
