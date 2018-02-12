using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        //O controller manipula as requisições que vem do usuario
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Thiago", "Rodrigues");
            var document = new Document("02165072190");
            var email = new Email("thiagorodriguescamara@gmail.com");
            var customer = new Customer(name, document, email, "9999999");
            var customers = new List<Customer>();

            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Thiago", "Rodrigues");
            var document = new Document("02165072190");
            var email = new Email("thiagorodriguescamara@gmail.com");
            return new Customer(name, document, email, "9999999");
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Thiago", "Rodrigues");
            var document = new Document("02165072190");
            var email = new Email("thiagorodriguescamara@gmail.com");
            var customer = new Customer(name, document, email, "9999999");
            var order = new Order(customer);

            var MOUSE = new Product("Mouse", "Mouse", "mouse.jpg", 99M, 10);
            var MONITOR = new Product("Monitor", "Monitor", "monitor.jpg", 99M, 10);

            order.AddItem(MONITOR, 5);
            order.AddItem(MONITOR, 5);
            var orders = new List<Order>();
            orders.Add(order);

            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand customerCommand)
        {
            var name = new Name(customerCommand.FirstName, customerCommand.LestName);
            var document = new Document(customerCommand.Document);
            var email = new Email(customerCommand.Email);
            var customer = new Customer(name, document, email, customerCommand.Phone);
            return customer;
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
           return new {Message = "Cliente Removido com sucesso!"};
        }

    }
}