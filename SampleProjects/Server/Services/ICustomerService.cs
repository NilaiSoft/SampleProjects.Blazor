using SampleProjects.Server.ViewModel;
using SampleProjects.Server.Models;

namespace SampleProjects.Server.Services
{
    public interface ICustomerService : IRepository<Customer, CustomerModel>
    {

    }
}
