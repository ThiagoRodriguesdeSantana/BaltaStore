using BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void Deve_validar_quando_commands_for_valido()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "thiago",
                LestName = "Rodrigues de Santana",
                Document = "02165072190",
                Email = "thiagorodriguescamara@gmail.com",
                Phone = "9999999999"

            };
            

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}
