using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Tests
{
    [TestClass]
    public class DocumentTest
    {
        private Document valid;
        private Document invalid;
        public DocumentTest()
        {
            this.valid = new Document("02165072190");
            this.invalid = new Document("12345678912");
            
        }
        [TestMethod]
        public void Retorna_Notificao_Quando_Valor_Nao_For_Valido()
        {
           Assert.AreEqual(false, invalid.IsValid);
        }
         [TestMethod]
        public void Retorna_Notificao_Quando_Valor_For_Valido()
        {
           Assert.AreEqual(true, valid.IsValid);
        }
    }
}
