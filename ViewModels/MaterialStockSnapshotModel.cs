using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartPortDev.ViewModels
{
    /// <summary>
    /// Snapshot view model
    /// </summary>
    public class MaterialStockSnapshotModel
    {
        public List<int> AvailableQuantity { get; set; }
        public int MaterialId { get; set; }
    }

    /// <summary>
    /// Snapshot history in format suitable for graphing
    /// </summary>
    /// 
    public class SnapshotResponse
    {
        public List<MaterialStockSnapshotModel> MaterialStockSnapshotModels { get; set; }
        public List<DateTime> Timeline { get; set; }
    }
}
