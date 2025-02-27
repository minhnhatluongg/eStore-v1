﻿using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class WishlistItem
    {
        public int WishlistItemId { get; set; }
        public int? WishlistId { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Wishlist? Wishlist { get; set; }
    }
}
