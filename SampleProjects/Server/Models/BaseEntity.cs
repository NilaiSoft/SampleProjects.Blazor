using System.ComponentModel.DataAnnotations;

namespace SampleProjects.Server.Models
{
    public class BaseEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public bool Deleted { get; set; }
        public bool Visibled { get; set; }
    }
}
