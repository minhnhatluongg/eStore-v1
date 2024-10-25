using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class Keyboard
    {
        public int KeyboardId { get; set; }
        public int? ProductId { get; set; }
        public string? Type { get; set; }
        public string? Connectivity { get; set; }
        public string? SwitchType { get; set; }
        public string? Layout { get; set; }

        public virtual Product? Product { get; set; }
    }
}
