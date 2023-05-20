using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjects.Shared.Dtos
{
    public class ProductDto
    {
        public ProductDto()
        {
            Id = 0;
            Name = string.Empty;
            Price = 0;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid GuidRecord { get; set; }
    }
}
