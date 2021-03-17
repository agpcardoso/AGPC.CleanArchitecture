using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces;
using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.UseCases.Customer
{
    public class GetUseCase : IGetUseCase
    {
        private IUnitOfWork _unitOfWork;
        public GetUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async ValueTask<CustomerEntity> ExecuteAsync(Guid id)
            => await _unitOfWork.CustomerRepository.GetByIdAsync(id);

        
    }
}
