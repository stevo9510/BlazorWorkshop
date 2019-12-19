using Microsoft.AspNetCore.Components;

namespace BlazorWorkshop.Pages
{
    public class CounterCode : ComponentBase
    {
        public int CurrentCount = 0;

        public void IncrementCount()
        {
            CurrentCount++;
        }
    }
}
