namespace SampleProjects.Shared.ViewModels.Product
{
    public class ProductVM
    {
        public ProductVM()
        {
            Name = string.Empty;
            Price = 0;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
