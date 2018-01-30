
using System;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext
{
    public class Order
    {
        public Customer Customer { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public IList<OrderItem> Itens { get; set; }
        public IList<Delivery> Deliverys { get; set; }

        public void Place()
        {
            //TODO: Gerar Notas
            
        }


    }
}
