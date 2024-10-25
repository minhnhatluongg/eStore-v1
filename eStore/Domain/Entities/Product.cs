using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            Headphones = new HashSet<Headphone>();
            Keyboards = new HashSet<Keyboard>();
            Laptops = new HashSet<Laptop>();
            OrderItems = new HashSet<OrderItem>();
            Reviews = new HashSet<Review>();
            WishlistItems = new HashSet<WishlistItem>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? Description { get; set; }
        public int? WarrantyPeriod { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Headphone> Headphones { get; set; }
        public virtual ICollection<Keyboard> Keyboards { get; set; }
        public virtual ICollection<Laptop> Laptops { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishlistItem> WishlistItems { get; set; }
    }
}
