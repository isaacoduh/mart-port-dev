using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartPortDev.Data
{
    public class MaterialStock
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AvailableQuantity { get; set; }
        public int IdealQuantity { get; set; }
        public Material Material { get; set; }
    }
}
