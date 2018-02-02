
using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _orderItem;
        private readonly IList<Delivery> _delivery;
        public Order(Customer customer)
        {
            Customer = customer;

            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _orderItem = new List<OrderItem>();
            _delivery = new List<Delivery>(); ;
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Itens => _orderItem.ToArray();
        public IReadOnlyCollection<Delivery> Deliverys => _delivery.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.ToString()} não tem qunatidade [{quantity}] de estoque!");

            var item = new OrderItem(product, quantity);
            _orderItem.Add(item);

        }

        public void AddDelivery(Delivery delivery)
        {
            _delivery.Add(delivery);
        }

        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            //TODO: Gerar Notas

        }
        public void Pay()
        {
            //validacoes
            Status = EOrderStatus.Paid;


        }
        public void Ship()
        {
            //a cada 5 produtod é uma entrega
            var delivies = new List<Delivery>();
            _delivery.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;
            foreach (var item in _orderItem)
            {
                if (count == 5)
                {
                    count = 1;
                    delivies.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
            }
            delivies.ForEach(c => c.Ship());
            delivies.ForEach(c => _delivery.Add(c));
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _delivery.ToList().ForEach(c => c.Cancel());
        }

    }
}
