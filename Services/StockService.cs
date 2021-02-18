using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MartPortDev.Data;

namespace MartPortDev.Services
{
    public class StockService : IStockService
    {
        private readonly AppDbContext _db;
        private readonly ILogger<StockService> _logger;

        public StockService(AppDbContext dbContext, ILogger<StockService> logger)
        {
            _db = dbContext;
            _logger = logger;
        }

        public MaterialStock GetByMaterialId(int materialId)
        {
            return _db.MaterialStocks.Include(ms => ms.Material).FirstOrDefault(ms => ms.Material.Id == materialId);
        }

        public List<MaterialStock> GetCurrentInventory()
        {
            return _db.MaterialStocks.Include(ms => ms.Material)
                .Where(ms => !ms.Material.IsArchived)
                .ToList();
        }

        public List<MaterialStockSnapshot> GetSnapshotHistory()
        {
            var latest = DateTime.UtcNow - TimeSpan.FromHours(6);
            return _db.MaterialStockSnapshots.Include(snap => snap.Material).Where(snap => snap.SnapshotTime > latest && !snap.Material.IsArchived).ToList();
        }


        // <summary>
        /// Updates number of units available of the provided material id
        /// Adjusts AvailableUnits by adjustment value
        /// </summary>
        /// <param name="id">materialId</param>
        /// <param name="adjustment">number of units added / removed from inventory</param>
        /// <returns></returns>
        public BaseServiceResponse<MaterialStock> ModifyAvailableUnits(int id, int adjustment)
        {
            var now = DateTime.UtcNow;
            try {
                var stock = _db.MaterialStocks.Include(stk => stk.Material)
                    .First(stk => stk.Material.Id == id);
                stock.AvailableQuantity += adjustment;

                try
                {
                    CreateSnapshot(stock);
                }catch(Exception e)
                {
                    _logger.LogError("Error creating stock snapshot.");
                    _logger.LogError(e.StackTrace);
                }
                _db.SaveChanges();
                return new BaseServiceResponse<MaterialStock>
                {
                    IsSuccess = true,
                    Data = stock,
                    Message = $"Material {id} stock adjusted",
                    Time = now
                };
            }catch(Exception e) {
                return new BaseServiceResponse<MaterialStock>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Error Updating MaterialStock AvailableUnit",
                    Time = now
                };
            }
        }


        private void CreateSnapshot(MaterialStock stock)
        {
            var now = DateTime.UtcNow;
            var snapshot = new MaterialStockSnapshot
            {
                SnapshotTime = now,
                Material = stock.Material,
                AvailableQuantity = stock.AvailableQuantity
            };
            _db.Add(snapshot);
        }
    }
}
