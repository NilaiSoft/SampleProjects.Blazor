using Microsoft.AspNetCore.Components;
using SampleProjects.Shared.Dtos;
using SampleProjects.Shared.ViewModels.Product;

namespace SampleProjects.Client.Pages
{
    public partial class Product_Create
    {
        private ProductVM? productVM = new();

        public async Task Create()
        {
            productVM.GuidRecord = Guid.NewGuid();

            var responce = await _httpClient.PostAsJsonAsync("api/Product/Create", productVM);
            if (responce.IsSuccessStatusCode)
                _navigationManager.NavigateTo("Product_Index");
        }
    }
}