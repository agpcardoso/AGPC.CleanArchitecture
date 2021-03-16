using AGPC.CleanArchitecture.Application.InfraInterfaces;
using AGPC.CleanArchitecture.Application.UseCases.Customer;
using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application
{
    public class CreateUseCase : ICreateUseCase
    {
        private IUnitOfWork _unitOfWork;
        public CreateUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask Execute(CustomerEntity customerEntity)
        {
            await _unitOfWork.CustomerRepository.AddAsync(customerEntity);

            _unitOfWork.SaveChanges();
        }
    }
}
