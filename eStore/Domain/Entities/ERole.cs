using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class ERole
    {
        public ERole()
        {
            EUsers = new HashSet<EUser>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<EUser> EUsers { get; set; }
    }
}
