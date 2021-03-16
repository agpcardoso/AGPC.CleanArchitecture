using AGPC.CleanArchitecture.Application.InfraInterfaces.Repositories;
using AGPC.CleanArchitecture.Domain.Entities;
using AGPC.CleanArchitecture.Infra.EntityFwkConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Infra.Repositories
{
    public class CustomerRepository : GenericRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

    }
}
