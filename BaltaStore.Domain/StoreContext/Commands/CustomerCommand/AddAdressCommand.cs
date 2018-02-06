using BaltaStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommand
{
    public class AddAdressCommand
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

    }
}
