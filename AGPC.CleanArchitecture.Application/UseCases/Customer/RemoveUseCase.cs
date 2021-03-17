using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces;
using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.UseCases.Customer
{
    public class RemoveUseCase : IRemoveUseCase
    {
        private IUnitOfWork _unitOfWork;
        public RemoveUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async ValueTask<int> ExecuteAsync(Guid id)
        {
            _unitOfWork.CustomerRepository.Delete(id);
            return _unitOfWork.SaveChanges();
        }
    }
}
