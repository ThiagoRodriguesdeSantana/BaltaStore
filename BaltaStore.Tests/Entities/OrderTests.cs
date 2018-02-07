using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Enums;
using System.Collections.Generic;

namespace BaltaStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Thiago", "Rodrigues");
            var document = new Document("02165072190");
            var email = new Email("thiagorodriguescamara@gmail.com");
            _customer = new Customer(name, document, email, "9999999");
            _order = new Order(_customer);

        }
        [TestMethod]
        public void Deve_criar_um_pedido_quando_for_valido()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        [TestMethod]
        public void Ao_criar_um_pedido_o_status_deve_ser_criado()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }
        [TestMethod]
        public void Ao_adicionar_um_novo_item_a_quanrtidade_deve_mudar()
        {
            _order.AddItem(_product[MOUSE], 5);
            _order.AddItem(_product[KEYBOARD], 5);

            Assert.AreEqual(2, _order.Itens.Count);
        }

        [TestMethod]
        public void Ao_adicionar_um_novo_item_deve_subtrair_a_quantidade_do_produto()
        {
            _order.AddItem(_product[MOUSE], 5);
            Assert.AreEqual(_product[MOUSE].QuantityOnHand, 5);

        }
        [TestMethod]
        public void Ao_confirmar_o_pedido_deve_gerar_um_numero()
        {
           _order.Place();
           Assert.AreNotEqual("", _order.Number);
        }
        [TestMethod]
        public void Ao_pagar_o_pedido_o_status_deve_modar_para_pago()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void A_cada_5_produtos_deve_garar_uma_entrega()
        {
            for (int i = 0; i < 10; i++)
            {
                _order.AddItem(_product[MOUSE], i);
            }
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }
        [TestMethod]
        public void Ao_cancelar_pedido_status_deve_ser_cancelado()
        {
           _order.Cancel();
           Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }
         public void Ao_cancelar_pedido_deve_cancelar_as_entregas()
        {
           for (int i = 0; i < 10; i++)
            {
                _order.AddItem(_product[MOUSE], i);
            }
            _order.Cancel();

            foreach (var item in _order.Deliveries)
            {
                 Assert.AreEqual(EOrderStatus.Canceled, item.Status);
            }
           
        }




        private Dictionary<string, Product> _product = new Dictionary<string, Product>
        {
            [MOUSE] = new Product("Mouse","Mouse","mouse.jpg",99M,10),
            [KEYBOARD] = new Product("Teclado","Teclado","keyboard.jpg",99M,10),
            [CHAIR] = new Product("Cadeira","Cadeira","chair.jpg",99M,10),
            [MONITOR] = new Product("Monitor","Monitor","monitor.jpg",99M,10),
        };

        private const string MOUSE = "mouse";
        private const string KEYBOARD = "keyboard";
        private const string CHAIR = "chair";
        private const string MONITOR = "monitor";


        public void CreatCustomer()
        {
            //Verificar se cpf ja exist
            //Verificar se email ja existe
            //Criar os VO's
            //Criar a Entidade
            //Validar as entidades e VO
            //Inserir o cliente do banco
            //Envia convite do Slack
            //Envia um e-mail de boas vindas 

        }

    }
}
