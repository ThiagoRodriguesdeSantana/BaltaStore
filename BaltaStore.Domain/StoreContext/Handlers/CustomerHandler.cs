using BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Outouts;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;
using System;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, 
        IcommandHandler<CreateCustomerCommand>,
        IcommandHandler<AddAdressCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailServices _emailServices;

        public CustomerHandler(ICustomerRepository customerRepository, IEmailServices emailServices)
        {
            _customerRepository = customerRepository;
            _emailServices = emailServices;
        }

        

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se CPF ja existe na base
            if (_customerRepository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já existe!");

            //Verificar se email ja existe na base
            if (_customerRepository.CheckEmail(command.Email))
                AddNotification("Email","Email já existe!");

            if (Invalid)
                return null;
            
            //Criar VOs
            var name = new Name(command.FirstName, command.LestName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            //Persistir cliente
            _customerRepository.Save(customer);

            //Enviar email de boas vindas
            _emailServices.Send(email.Adress, "thiagorodriguescamara@gmail.com", "Bem vindo","Seja bem vindo!");

            return new CreatCustomerCommandResult(customer.Id, name.ToString(), email.Adress);
        }

        public ICommandResult Handle(AddAdressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
