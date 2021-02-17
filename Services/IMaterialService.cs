using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartPortDev.Data;

namespace MartPortDev.Services
{
    public interface IMaterialService
    {
        List<Data.Material> GetAllMaterials();
        Data.Material GetMaterialById(int id);
        BaseServiceResponse<Data.Material> CreateMaterial(Data.Material material);
        BaseServiceResponse<Data.Material> ArchiveMaterial(int id);
    }
}
