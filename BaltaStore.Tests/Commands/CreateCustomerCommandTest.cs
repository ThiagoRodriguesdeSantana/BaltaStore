using BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTest
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
            Assert.AreEqual(true, command.Valid());
            //Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }
    }
}
