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
        public EventCallback<Customer> CustomerSelectEvent { get; set; }

        [Parameter]
        public Customer SelectedCustomer { get; set; }

        [Parameter]
        public EventCallback<int> CustomerResetEvent { get; set; }

        protected async Task CustomerSelected(ChangeEventArgs args)
        {
            SelectedCustomer = Customers.Where(cust => cust.CustomerId.ToString() == args.Value.ToString()).First();
            await CustomerSelectEvent.InvokeAsync(SelectedCustomer);
        }

        protected async Task ResetButtonClicked()
        {
            await CustomerResetEvent.InvokeAsync(SelectedCustomer.CustomerId);
        }
    }
}
