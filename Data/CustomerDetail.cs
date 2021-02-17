using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MartPortDev.Data
{
    public class CustomerDetail
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string PrimaryAddress { get; set; }

        public string AlternateAddress { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(15)]
        public string State { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(32)]
        public string Country { get; set; }
    }
}
