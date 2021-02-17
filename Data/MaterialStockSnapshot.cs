using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartPortDev.Data
{
    public class MaterialStockSnapshot
    {
        public int Id { get; set; }
        public DateTime SnapshotTime { get; set; }
        public int AvailableQuantity { get; set; }
        public Material Material { get; set; }
    }
}
