
using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Entities;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private IList<Adress> _Adress;
        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _Adress = new List<Adress>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Adress> Adress { get; private set; }

        public override string ToString() => this.Name.ToString();

        public IReadOnlyCollection<Adress> GetAdress() => _Adress.ToArray();
        public void AddAdress(Adress adress)
        {
            _Adress.Add(adress);
        }

    }

}