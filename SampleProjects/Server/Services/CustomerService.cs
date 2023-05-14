﻿using Microsoft.EntityFrameworkCore;
using SampleProjects.Server.Data;
using SampleProjects.Server.Dtos;
using SampleProjects.Server.Models;

namespace SampleProjects.Server.Services
{
    public class CustomerService : Repository<Customer, CustomerModel>, ICustomerService
    {
        public CustomerService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
