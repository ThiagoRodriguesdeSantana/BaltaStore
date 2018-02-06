
using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public List<OrderItem> Itens { get; private set; }
        public List<Delivery> Deliveries { get; private set; }

        public Order(Customer customer)
        {
            Customer = customer;

            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            Itens = new List<OrderItem>();
            Deliveries = new List<Delivery>(); ;
        }

       

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.ToString()} não tem qunatidade [{quantity}] de estoque!");

            var item = new OrderItem(product, quantity);
            Itens.Add(item);

        }

        public void AddDelivery(Delivery delivery)
        {
            Deliveries.Add(delivery);
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
            //Deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;
            foreach (var item in Itens)
            {
                if (count == 5)
                {
                    count = 1;
                    delivies.Add(new Delivery(DateTime.Now.AddDays(5)));
                    continue;
                }
                count++;
            }
            delivies.ForEach(c => c.Ship());
            delivies.ForEach(c => Deliveries.Add(c));
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            Deliveries.ToList().ForEach(c => c.Cancel());
        }

    }
}
