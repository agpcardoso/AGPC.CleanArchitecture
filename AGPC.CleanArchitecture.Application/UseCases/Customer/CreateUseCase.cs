using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces;
using AGPC.CleanArchitecture.Application.UseCases.Customer;
using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.UseCases.Customer
{
    public class CreateUseCase : ICreateUseCase
    {
        private IUnitOfWork _unitOfWork;
        public CreateUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

        public async ValueTask<Guid> ExecuteAsync(CustomerEntity customerEntity)
        {
            if (customerEntity.Underage() == true)
                throw new UseCaseException("Underage customers are not allowed");

            if (string.IsNullOrEmpty(customerEntity.Name))
                throw new UseCaseException("Customer name empty");

            Guid _customerId = await _unitOfWork.CustomerRepository.AddAsync(customerEntity);

            _unitOfWork.SaveChanges();

            return _customerId;
        }
    }
}
