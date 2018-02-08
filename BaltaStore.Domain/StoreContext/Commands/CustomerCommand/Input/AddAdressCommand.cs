using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommand.Input
{
    public class AddAdressCommand : Notifiable, ICommando
    {
        public Guid Id { get; set; }
        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Complement { get;  set; }
        public string Districty { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
        public EAdressType Type { get;  set; }

        public event EventHandler CanExecuteChanged;

        public bool Valid()
        {
            return IsValid;
        }
    }
}
