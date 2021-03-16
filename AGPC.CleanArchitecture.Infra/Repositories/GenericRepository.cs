using AGPC.CleanArchitecture.Application.InfraInterfaces.Repositories;
using AGPC.CleanArchitecture.Domain.Entities;
using AGPC.CleanArchitecture.Infra.EntityFwkConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Infra.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext _context;
        private DbSet<TEntity> _entity;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
            _entity = context.Set<TEntity>();
        }

        public async ValueTask AddAsync(TEntity data)
        {
            if(data == null) throw new ArgumentNullException("data parameter is null");

            await _entity.AddAsync(data);
        }

        public void Delete(TEntity data)
        {
            if (data == null) throw new ArgumentNullException("data parameter is null");

             _context.Set<TEntity>().Remove(data);
        }

        public void Update(TEntity data)
        {
            if (data == null) throw new ArgumentNullException("data parameter is null");

             _context.Set<TEntity>().Update(data);
        }


        public async ValueTask<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity,bool>> predicate)
            => await _context.Set<TEntity>().Where(predicate).ToListAsync<TEntity>();

        public async ValueTask<TEntity> GetByIdAsync(Guid id)
            => await _context.Set<TEntity>().FindAsync(id);
    }
}
