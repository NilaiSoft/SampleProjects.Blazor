namespace SampleProjects.Client.Pages
{
    public partial class Product_Index
    {
        private IList<ProductDto>? productDtos;

        protected override async Task OnInitializedAsync()
        {
            productDtos = await _httpClient.GetFromJsonAsync<IList<ProductDto>>("api/Product/Index");
        }

        public async Task Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Product/Delete/{id}");
            if (result.IsSuccessStatusCode)
            {
                productDtos = await _httpClient.GetFromJsonAsync<IList<ProductDto>>("api/Product/Index");
            }
        }
    }
}