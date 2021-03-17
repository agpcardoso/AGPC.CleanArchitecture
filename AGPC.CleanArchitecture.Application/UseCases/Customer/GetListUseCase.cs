using AGPC.CleanArchitecture.Application.UseCases.Customer.InfraInterfaces;
using AGPC.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.Application.UseCases.Customer
{
    public class GetListUseCase : IGetListUseCase
    {
        private IUnitOfWork _unitOfWork;
        public GetListUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask<IEnumerable<CustomerEntity>> ExecuteAsync(string name)
            =>  await _unitOfWork.CustomerRepository.GetListAsync(x => x.Name.StartsWith(name));

        public async ValueTask<IEnumerable<CustomerEntity>> ExecuteAsync()
            => await _unitOfWork.CustomerRepository.GetListAsync(null);


    }
}
