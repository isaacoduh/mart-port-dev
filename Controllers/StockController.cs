using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MartPortDev.Services;
using MartPortDev.Serialization;
using MartPortDev.ViewModels;

namespace MartPortDev.Controllers
{
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger, IStockService stockService)
        {
            _stockService = stockService;
            _logger = logger;
        }

        [HttpGet("/api/stock")]
        public ActionResult GetCurrentStock()
        {
            _logger.LogInformation("Getting all stock information");
            var stock = _stockService.GetCurrentInventory().Select(ms => new MaterialStockModel
            {
                Id = ms.Id,
                Material = MaterialMapper.SerializeMaterialModel(ms.Material),
                IdealQuantity = ms.IdealQuantity,
                AvailableQuantity = ms.AvailableQuantity
            }).OrderBy(stk => stk.Material.Name).ToList();

            return Ok(stock);
        }

        [HttpPatch("/api/stock")]
        public ActionResult UpdateStock([FromBody] ShipmentModel shipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = shipment.MaterialId;
            var adjustment = shipment.Adjustment;
            var stock = _stockService.ModifyAvailableUnits(id, adjustment);
            return Ok(stock);
        }

        [HttpGet("/api/stock/snapshot")]
        public ActionResult GetSnapshotHistory()
        {
            _logger.LogInformation("Getting snapshot history information");
            try
            {
                var snapshotHistory = _stockService.GetSnapshotHistory();
                var timelineMarkers = snapshotHistory.Select(t => t.SnapshotTime).Distinct().ToList();
                var snapshots = snapshotHistory.GroupBy(hist => hist.Material, hist => hist.AvailableQuantity, (key, g) => new MaterialStockSnapshotModel
                {
                    MaterialId = key.Id,
                    AvailableQuantity = g.ToList()
                }).OrderBy(hist => hist.MaterialId).ToList();

                var viewModel = new SnapshotResponse
                {
                    Timeline = timelineMarkers,
                    MaterialStockSnapshots = snapshots
                };
                return Ok(viewModel);
            }catch(Exception e)
            {
                _logger.LogError("error getting snapshot history.");
                _logger.LogError(e.StackTrace);
                return BadRequest("Error retrieving history");
            }
        }
    }
}
