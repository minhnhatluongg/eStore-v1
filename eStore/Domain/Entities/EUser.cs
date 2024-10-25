using Domain.Common;
using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class EUser : BaseEntity
    {
        public EUser()
        {
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            ShoppingCarts = new HashSet<ShoppingCart>();
            Wishlists = new HashSet<Wishlist>();
        }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ERole? Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
