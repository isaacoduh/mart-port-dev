using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartPortDev.Data;

namespace MartPortDev.Services
{
    public interface IStockService
    {
        public List<MaterialStock> GetCurrentInventory();
        public BaseServiceResponse<MaterialStock> ModifyAvailableUnits(int id, int adjustment);
        public MaterialStock GetByMaterialId(int materialId);
        public List<MaterialStockSnapshot> GetSnapshotHistory();
    }
}
