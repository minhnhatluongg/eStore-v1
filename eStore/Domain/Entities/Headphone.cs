using System;
using System.Collections.Generic;

namespace eStore.Infrastructure.Persistence.Entities
{
    public partial class Headphone
    {
        public int HeadphoneId { get; set; }
        public int? ProductId { get; set; }
        public string? Type { get; set; }
        public string? Connectivity { get; set; }
        public string? BatteryLife { get; set; }
        public string? FrequencyResponse { get; set; }

        public virtual Product? Product { get; set; }
    }
}
