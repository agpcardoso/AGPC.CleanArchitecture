using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.InfraInterfaces.Repositories

{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        ValueTask AddAsync(TEntity data);
        void Update(TEntity data);
        void Delete(TEntity data);
        ValueTask<TEntity> GetByIdAsync(Guid id);
        ValueTask<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
