using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class Wishlist
    {
        public Wishlist()
        {
            WishlistItems = new HashSet<WishlistItem>();
        }

        public int WishlistId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual EUser? User { get; set; }
        public virtual ICollection<WishlistItem> WishlistItems { get; set; }
    }
}
