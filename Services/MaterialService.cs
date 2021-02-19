using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartPortDev.Data;

namespace MartPortDev.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly AppDbContext _db;

        public MaterialService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        

        /// <summary>
        /// Retrieves all Materials 
        /// </summary>
        /// <returns></returns>
        public List<Data.Material> GetAllMaterials()
        {
            return _db.Materials.ToList();
        }

        /// <summary>
        /// Retrieves a material from the database based on primary key
        /// </summary>
        /// 
        public Material GetMaterialById(int id)
        {
            return _db.Materials.Find(id);
        }



        public BaseServiceResponse<Material> CreateMaterial(Material material)
        {
            try {
                _db.Materials.Add(material);
                var newStock = new MaterialStock
                {
                    Material = material,
                    AvailableQuantity = 0,
                    IdealQuantity = 13

                };
                _db.MaterialStocks.Add(newStock);
                _db.SaveChanges();
                return new BaseServiceResponse<Material>
                {
                    Data = material,
                    Time = DateTime.UtcNow,
                    Message = "New Material Added!",
                    IsSuccess = true
                };
            }catch(Exception e) {
                return new BaseServiceResponse<Material>
                {
                    Data = material,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false

                };
            }
        }


        // <summary>
        /// Archives a Material by setting boolean IsArchived to true
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public BaseServiceResponse<Material> ArchiveMaterial(int id)
        {
            try {
                var material = _db.Materials.Find(id);
                material.IsArchived = true;
                _db.SaveChanges();

                return new BaseServiceResponse<Material>
                {
                    Data = material,
                    Time = DateTime.UtcNow,
                    Message = "Material Archvied Successfully",
                    IsSuccess = true
                };
            }catch(Exception e) {
                return new BaseServiceResponse<Material>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

    }
}
