﻿namespace SampleProjects.Server.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Name = string.Empty;
            Price = 0;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
