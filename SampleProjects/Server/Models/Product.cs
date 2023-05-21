using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProjects.Server.Models
{
    public class Product : BaseEntity, ISoftDeletedEntity
    {
        public Product()
        {
            Name = string.Empty;
            Price = 0;
            GuidRecord = Guid.Empty;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid GuidRecord { get; set; }
        
        [ScaffoldColumn(false)]
        public bool Deleted { get; set; }
    }
}
