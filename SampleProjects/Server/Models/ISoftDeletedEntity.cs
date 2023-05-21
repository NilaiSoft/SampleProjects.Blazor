using System.ComponentModel.DataAnnotations;

namespace SampleProjects.Server.Models
{
    public interface ISoftDeletedEntity
    {
        public bool Deleted { get; set; }
    }
}
