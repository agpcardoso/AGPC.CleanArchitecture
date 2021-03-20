using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces.Repositories

{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        ValueTask<Guid> AddAsync(TEntity data);
        void Update(TEntity data);
        void Delete(Guid id);
        ValueTask<TEntity> GetByIdAsync(Guid id);
        ValueTask<IEnumerable<TEntity>> GetListAsync();
    }
}
