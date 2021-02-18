using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartPortDev.ViewModels;

namespace MartPortDev.Serialization
{
    public static class MaterialMapper
    {
        /// <summary>
        /// Maps a Material data model to a Material view model
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        
        public static MaterialModel SerializeMaterialModel(Data.Material material)
        {
            return new MaterialModel
            {
                Id = material.Id,
                CreatedAt = material.CreatedAt,
                UpdatedAt = material.UpdatedAt,
                Price = material.Price,
                Name = material.Name,
                Description = material.Description,
                IsArchived = material.IsArchived
            };
        }

        /// <summary>
        /// Maps a MaterialModel view model to a Material data model
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public static Data.Material SerializeMaterialModel(MaterialModel material)
        {
            return new Data.Material
            {
                Id = material.Id,
                CreatedAt = material.CreatedAt,
                UpdatedAt = material.UpdatedAt,
                Price = material.Price,
                Name = material.Name,
                Description = material.Description,
                IsArchived = material.IsArchived,
            };
        }
    }
}
