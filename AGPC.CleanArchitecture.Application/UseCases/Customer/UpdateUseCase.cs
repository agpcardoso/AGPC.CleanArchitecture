using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces;
using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.UseCases.Customer
{
    public class UpdateUseCase : IUpdateUseCase
    {
        private IUnitOfWork _unitOfWork;
        public UpdateUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask<int> ExecuteAsync(CustomerEntity customerEntity)
        {
            if (customerEntity.Underage() == true)
                throw new UseCaseException("Underage customers are not allowed");

            if (string.IsNullOrEmpty(customerEntity.Name))
                throw new UseCaseException("Customer name empty");


            _unitOfWork.CustomerRepository.Update(customerEntity);
            
            return _unitOfWork.SaveChanges();
        }
    }
}
