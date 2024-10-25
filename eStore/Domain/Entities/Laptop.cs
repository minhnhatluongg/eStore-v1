using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class Laptop
    {
        public int LaptopId { get; set; }
        public int? ProductId { get; set; }
        public string? Processor { get; set; }
        public string? Ram { get; set; }
        public string? Storage { get; set; }
        public string? ScreenSize { get; set; }
        public string? Gpu { get; set; }
        public string? BatteryCapacity { get; set; }
        public string? OperatingSystem { get; set; }

        public virtual Product? Product { get; set; }
    }
}
