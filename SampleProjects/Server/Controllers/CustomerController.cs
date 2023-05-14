using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleProjects.Server.Dtos;
using SampleProjects.Server.Models;
using SampleProjects.Server.Services;
using SampleProjects.Web.BaseController;

namespace SampleProjects.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<Customer, CustomerModel>
    {
        public CustomerController(IRepository<Customer, CustomerModel> cityRepository, IMapper mapper)
            : base(cityRepository, mapper)
        {
        }
    }
}
