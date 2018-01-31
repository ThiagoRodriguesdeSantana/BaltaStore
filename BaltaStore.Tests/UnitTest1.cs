using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c  = new Customer("thiago","rodrigues","123456","thiagorodriguescamara@gmail.com","1234567","rua 231");
        }
    }
}
