namespace SampleProjects.Server.Dtos
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Mobile = string.Empty;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
    }
}
