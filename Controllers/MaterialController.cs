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
    public class MaterialController : ControllerBase
    {
        private readonly ILogger<MaterialController> _logger;
        private readonly IMaterialService _materialService;


        public MaterialController(ILogger<MaterialController> logger, IMaterialService materialService)
        {
            _logger = logger;
            _materialService = materialService;
        }

        [HttpPost("/api/material")]
        public ActionResult AddMaterial([FromBody] MaterialModel material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Adding Material");
            var newMaterial = MaterialMapper.SerializeMaterialModel(material);
            var newMaterialResponse = _materialService.CreateMaterial(newMaterial);
            return Ok(newMaterialResponse);
        }

        [HttpGet("/api/material")]
        public ActionResult GetMaterial()
        {
            _logger.LogInformation("Getting all Materials");
            var materials = _materialService.GetAllMaterials();

            var materialViewModels = materials.Select(MaterialMapper.SerializeMaterialModel);
            return Ok(materialViewModels);
        }

        /// <summary>
        /// Archives an existing material
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("api/material/{id}")]
        public ActionResult ArchiveMaterial(int id)
        {
            _logger.LogInformation("Archiving Material");
            var archiveResult = _materialService.ArchiveMaterial(id);
            return Ok(archiveResult);
        }
    }
}
