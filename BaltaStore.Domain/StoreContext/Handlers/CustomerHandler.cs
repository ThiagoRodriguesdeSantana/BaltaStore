using BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input;
using BaltaStore.Shared.Commands;
using FluentValidator;
using System;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, IcommandHandler<CreateCustomerCommand>, IcommandHandler<AddAdressCommand>
    {


        public ICommandResult Handle(CreateCustomerCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(AddAdressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
