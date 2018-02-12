using BaltaStore.Shared.Commands;
using System;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Outouts
{
    public class CreatCustomerCommandResult : ICommandResult
    {
        public CreatCustomerCommandResult(Guid id, string name,  string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        public CreatCustomerCommandResult()
        {

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       
    }
}
