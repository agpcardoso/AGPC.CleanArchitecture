using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces.Repositories;
using AGPC.CleanArchitecture.Domain.Entities;
using AGPC.CleanArchitecture.Infra.EntityFwkConfig;
using Microsoft.EntityFrameworkCore;
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

        public async ValueTask<IEnumerable<CustomerEntity>> GetListAsync(string name)
            => await _context.Set<CustomerEntity>().Where(x => x.Name.StartsWith(name)).ToListAsync<CustomerEntity>();
        

    }
}
