using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }
        public int? StatusOrdersId { get; set; }

        public virtual TypeStatusOrder? StatusOrders { get; set; }
        public virtual EUser? User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
