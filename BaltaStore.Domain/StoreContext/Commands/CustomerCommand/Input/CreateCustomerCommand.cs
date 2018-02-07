using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input
{
    public class CreateCustomerCommand : Notifiable, ICommando
    {
        public string FirstName { get; set; }
        public string LestName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Nome muito curto")
                .HasMaxLen(FirstName, 40, "FirstName", "Nome muito longo")
                .HasMinLen(LestName, 3, "LestName", "Nome muito curto")
                .HasMaxLen(LestName, 40, "LestName", "Nome muito longo")
                .IsEmail(Email, "Email", "Email invalido")
                .HasLen(Document, 11, "Document", "CPF inválido")

                );
            return IsValid;
        }
    }
}
