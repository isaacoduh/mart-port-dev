using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartPortDev.ViewModels
{
    public class MaterialStockModel
    {
        public int Id { get; set; }
        public int AvailableQuantity { get; set; }
        public int IdealQuantity { get; set; }

        public MaterialModel Material { get; set; }
    }
}
