using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual EUser? User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
