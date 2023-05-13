namespace SampleProjects.Client.Pages
{
    public partial class Customer_Index
    {
        private IList<CustomerDto>? customerDtos;
        private CustomerDto? customerDto;

        protected override async Task OnInitializedAsync()
        {
            customerDtos = await _httpClient.GetFromJsonAsync<IList<CustomerDto>>("api/Customer/Index");
        }

        public async Task Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Customer/Delete/{id}");
            if (result.IsSuccessStatusCode)
            {
                customerDtos = await _httpClient.GetFromJsonAsync<IList<CustomerDto>>("api/Customer/Index");
            }
        }

        public async Task Edit(int id)
        {
            customerDto = await _httpClient.GetFromJsonAsync<CustomerDto>("api/Customer/Edit");
        }
    }
}