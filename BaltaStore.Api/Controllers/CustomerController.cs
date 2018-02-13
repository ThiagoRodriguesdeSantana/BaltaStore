using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Outouts;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _customerHandler;

        public CustomerController(ICustomerRepository repository
                                        , CustomerHandler customerHandler)
        {
            _repository = repository;
            _customerHandler = customerHandler;
        }
        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        //Location = ResponseCacheLocation.Client Armazena o cache na maquina do cliente
        //[ResponseCache(Location = ResponseCacheLocation.Client,Duration = 60)] 
        //Cache-Control: public, max-age=60
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCutomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrder(id);
        }

        [HttpPost]
        [Route("customers")]
        public object Post([FromBody]CreateCustomerCommand customerCommand)
        {
            var result = (CreatCustomerCommandResult)_customerHandler.Handle(customerCommand);

            if (_customerHandler.Invalid)
                return BadRequest(_customerHandler.Notifications);

            return result;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand customerCommand)
        {
            var name = new Name(customerCommand.FirstName, customerCommand.LestName);
            var document = new Document(customerCommand.Document);
            var email = new Email(customerCommand.Email);
            var customer = new Customer(name, document, email, customerCommand.Phone);
            return customer;
        }
        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { Message = "Cliente Removido com sucesso!" };
        }

    }
}