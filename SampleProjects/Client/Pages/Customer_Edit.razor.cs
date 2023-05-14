using Microsoft.AspNetCore.Components;

namespace SampleProjects.Client.Pages
{
    public partial class Customer_Edit
    {
        private CustomerVM? customerVM = new();

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            customerVM = await _httpClient.GetFromJsonAsync<CustomerVM>($"api/Customer/Edit/{Id}");
        }

        public async Task Edit()
        {
            var response = await _httpClient.PostAsJsonAsync("api/Customer/Edit", customerVM);
            if (response.IsSuccessStatusCode)
                _navigationManager.NavigateTo("Customer_Index");
        }
    }
}