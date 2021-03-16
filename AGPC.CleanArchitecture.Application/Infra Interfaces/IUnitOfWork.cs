using AGPC.CleanArchitecture.Application.InfraInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.InfraInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        bool BeginTransaction();
        int SaveChanges();
        int CommitTransaction();
    }
}
