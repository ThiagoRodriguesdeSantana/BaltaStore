using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;


namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    class PlaceOrderCommand : Notifiable, ICommando
    {
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItens { get; set; }

        public PlaceOrderCommand()
        {
            OrderItens = new List<OrderItemCommand>();
        }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
               .Requires()
               .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
               .IsGreaterThan(OrderItens.Count, 0, "OrderItens", "Nenhum item pedido")

               );
            return IsValid;
        }
    }


}
