using AutoMapper;
using SampleProjects.Server.ViewModel;
using SampleProjects.Server.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Customer, CustomerModel>().ReverseMap();
        CreateMap<ProductModel, Product>().ReverseMap();
    }
}