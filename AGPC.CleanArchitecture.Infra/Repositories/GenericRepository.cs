using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces.Repositories;
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

        public async ValueTask<Guid> AddAsync(TEntity data)
        {
            if(data == null) throw new ArgumentNullException("data parameter is null");

            if (data.Id == Guid.Empty)
                data.Id = Guid.NewGuid();

            await _entity.AddAsync(data);

            return data.Id;
        }

        public void Delete(Guid id)
        {
            TEntity _entityToDelete = _entity.Find(id);

            if (_entityToDelete == null)
                return;

            if(this._context.Entry(_entityToDelete).State == EntityState.Detached)
                _entity.Attach(_entityToDelete);

            _context.Set<TEntity>().Remove(_entityToDelete);
        }

        public void Update(TEntity data)
        {
            if (data == null) throw new ArgumentNullException("data parameter is null");
            
            _entity.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }


        public async ValueTask<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return await _context.Set<TEntity>().ToListAsync<TEntity>();
            else
                return await _context.Set<TEntity>().Where(predicate).ToListAsync<TEntity>();
        }

        public async ValueTask<TEntity> GetByIdAsync(Guid id)
            => await _context.Set<TEntity>().FindAsync(id);
    }
}
