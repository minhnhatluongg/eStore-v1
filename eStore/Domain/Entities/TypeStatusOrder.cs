using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class TypeStatusOrder
    {
        public TypeStatusOrder()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusOrdersId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
