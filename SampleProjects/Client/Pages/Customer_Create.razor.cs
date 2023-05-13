namespace SampleProjects.Client.Pages
{
    public partial class Customer_Create
    {
        private CustomerVM customerVM = new();
        public async Task Create()
        {
            var response = await _httpClient.PostAsJsonAsync("api/Customer/Create", customerVM);
            if (response.IsSuccessStatusCode)
                _navigationManager.NavigateTo("Customer_Index");
        }
    }
}