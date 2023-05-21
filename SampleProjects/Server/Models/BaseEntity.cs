using System.ComponentModel.DataAnnotations;

namespace SampleProjects.Server.Models
{
    public class BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        
        public int Id { get; set; }

        public bool Visibled { get; set; }
    }
}
