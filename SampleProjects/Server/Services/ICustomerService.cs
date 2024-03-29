﻿using SampleProjects.Server.Dtos;
using SampleProjects.Server.Models;

namespace SampleProjects.Server.Services
{
    public interface ICustomerService : IEntityRepository<Customer, CustomerModel>
    {

    }
}
