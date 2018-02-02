using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string adress)
        {
            Adress = adress;
            AddNotifications(new ValidationContract().Requires().IsEmail(adress, "Email", $"O email {adress} é inválido!"));
        }

        public string Adress { get; private set; }

        public override string ToString() => Adress;

    }

}