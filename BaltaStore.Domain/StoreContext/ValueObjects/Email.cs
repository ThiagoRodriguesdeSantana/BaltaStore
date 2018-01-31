namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email
    {
        public Email(string adress)
        {
            Adress = adress;
        }

        public string Adress { get; private set; }

        public override string ToString() => Adress;

    }

}