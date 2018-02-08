using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Adress : Entity
    {
        public Adress(string street, string number, string complement, string districty, string city, string state, string country, string zipCode, EAdressType type)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Districty = districty;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Districty { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAdressType Type { get; private set; }


        public override string ToString()
                => $"Rua: {Street}, Nº:{Number}, Complemento:{Complement} {City}/{State}";

    }

}