using AGPC.CleanArchitecture.Application.UseCases.Customer;
using AGPC.CleanArchitecture.Domain.Entities;
using AGPC.CleanArchitecture.SPA.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AGPC.CleanArchitecture.SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public async ValueTask<IActionResult> Get([FromServices]IGetListUseCase getListUseCase)
        {
            var _customerEntityList = await getListUseCase.ExecuteAsync();

            if(_customerEntityList != null && _customerEntityList.Any() == true)
                return Ok(MapperToGetListResponse(_customerEntityList));

            return NoContent();
        }
        [HttpGet("FilterByName/{name}")]
        public async ValueTask<IActionResult> FilterByName([FromRoute] string name, [FromServices] IGetListUseCase getListUseCase)
        {
            var _customerEntityList = await getListUseCase.ExecuteAsync(name);

            if (_customerEntityList != null && _customerEntityList.Any() == true)
                return Ok(MapperToGetListResponse(_customerEntityList));

            return NoContent();
        }
        private GetListResponse MapperToGetListResponse(IEnumerable<CustomerEntity>customers)
        {
            GetListResponse _response = new GetListResponse();
            var _customersList = new List<GetListResponse.Customer>();
            foreach (var item in customers)
            {
                _customersList.Add(new GetListResponse.Customer()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age
                });

            }

            _response.Customers = _customersList;
            return _response;
        }





        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get(Guid id, [FromServices] IGetUseCase getUseCase)
        {
            var _customerEntity = await getUseCase.ExecuteAsync(id);

            if (_customerEntity != null)
                return Ok(MapperToGetResponse(_customerEntity));

            return NoContent();
        }
        private GetResponse MapperToGetResponse(CustomerEntity customer)
        {
                var _response = new GetResponse()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Age = customer.Age
                };

            return _response;
        }





        [HttpPost]
        public async ValueTask<IActionResult> Post([FromBody] PostRequest value, [FromServices] ICreateUseCase createUseCase)
        {
            var _customerId = await createUseCase.ExecuteAsync(MapperToCustomerEntity(value));

            if (_customerId != Guid.Empty)
                return Created(nameof(Get), new PostResponse() { Id = _customerId });

            return NoContent();
        }
        private CustomerEntity MapperToCustomerEntity(PostRequest request)
        {
            return new CustomerEntity()
            {
                Age = request.Age,
                Name = request.Name
            };
        }





        [HttpPut]
        public async ValueTask<IActionResult> Put([FromBody] PutRequest value, [FromServices] IUpdateUseCase updateUseCase)
        {
            var _ret = await updateUseCase.ExecuteAsync(MapperToCustomerEntity(value));

            if (_ret > 0)
                return Ok(new { Id = value.Id });

            return NoContent();

        }
        private CustomerEntity MapperToCustomerEntity(PutRequest request)
        {
            return new CustomerEntity()
            {
                Id = request.Id,
                Age = request.Age,
                Name = request.Name
            };
        }





        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete(Guid id, [FromServices]IRemoveUseCase removeUseCase)
        {
            var _ret = await removeUseCase.ExecuteAsync(id);

            if (_ret > 0)
                return Ok();

            return NoContent();
        }
    }
}
