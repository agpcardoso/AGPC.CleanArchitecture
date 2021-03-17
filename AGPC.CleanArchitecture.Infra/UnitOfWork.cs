using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces.Repositories;
using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces;
using AGPC.CleanArchitecture.Infra.EntityFwkConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private bool _transactionStarted = false;
        public ICustomerRepository CustomerRepository { get; }

        public UnitOfWork(AppDbContext context, ICustomerRepository customerRepository)
        {
            this._context = context;
            this.CustomerRepository = customerRepository;
        }

        public bool BeginTransaction()
        {
            if (!_transactionStarted)
            {
                _transactionStarted = true;
                return true;
            }

            return false;
        }

        public int SaveChanges()
        { 
            if (!_transactionStarted)
                return _context.SaveChanges();

            return 0;
        }

        public int CommitTransaction()
        {
            if (_transactionStarted == true)
                return _context.SaveChanges();

            return 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}
