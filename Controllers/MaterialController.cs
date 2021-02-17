using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MartPortDev.Services;
using MartPortDev.Serialization;

namespace MartPortDev.Controllers
{
    
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ILogger<MaterialController> _logger;
        private readonly IMaterialService _materialService;


        public MaterialController(ILogger<MaterialController> logger, IMaterialService materialService)
        {
            _logger = logger;
            _materialService = materialService;
        }

        [HttpGet("/api/material")]
        public ActionResult GetMaterial()
        {
            _logger.LogInformation("Getting all Materials");
            var materials = _materialService.GetAllMaterials();

            var materialViewModel = materials.Select(MaterialMapper.SerializeMaterialModel);
            return Ok(materialViewModel);
        }
    }
}
