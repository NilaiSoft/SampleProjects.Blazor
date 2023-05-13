namespace SampleProjects.Server.Models
{
    public class Customer:BaseEntity
    {
        public Customer()
        {
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
    }
}
