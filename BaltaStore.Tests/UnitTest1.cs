using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Thiago", "Rodrigues");
            var document = new Document("02165072190");
            var email = new Email("thaigorodriguescamara@gmail.com");

            var c = new Customer(name, document, email, "9999999999");
            var mouse = new Product("Mouse", "Rato", "image.png", 50.90M, 10);
            var teclado = new Product("teclado", "teclado", "image.png", 159.90M, 10);
            var impressora = new Product("impressora", "impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("cadeira", "cadeira", "image.png", 559.90M, 10);


            var order = new Order(c);

            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(impressora, 5));
            //order.AddItem(new OrderItem(cadeira , 5));

            order.Place();

            var valid = order.IsValid;

            order.Pay();

            order.Ship();

            order.Cancel();

        }
    }
}
