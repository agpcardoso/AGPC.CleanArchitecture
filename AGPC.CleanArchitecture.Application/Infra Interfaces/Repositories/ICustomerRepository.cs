using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.InfraInterfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<CustomerEntity>
    {
    }
}
