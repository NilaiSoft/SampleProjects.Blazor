namespace SampleProjects.Server.ViewModel
{
    public class ProductModel
    {
        public ProductModel()
        {
            Id = 0;
            Name = string.Empty;
            Price = 0;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
