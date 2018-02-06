using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input
{
    public class CreateCustomerCommand
    {
        public string FirstName { get; set; }
        public string LestName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
