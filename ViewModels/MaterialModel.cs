using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartPortDev.ViewModels
{
    /// <summary>
    ///     Material entity DTO
    /// </summary>
    /// 
    public class MaterialModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsArchived { get; set; }
        
    }
}
