using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<CustomerEntity>
    {
        ValueTask<IEnumerable<CustomerEntity>> GetListAsync(string name);
    }
}
