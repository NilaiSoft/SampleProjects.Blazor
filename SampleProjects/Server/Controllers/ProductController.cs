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
    public class ProductController : BaseController<Product, ProductModel>
    {
        public ProductController(IRepository<Product, ProductModel> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
