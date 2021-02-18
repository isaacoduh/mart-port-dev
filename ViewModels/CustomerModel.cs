using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MartPortDev.ViewModels
{
    public class CustomerModel
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [MaxLength(32)] public string FirstName { get; set; }
        [MaxLength(32)] public string LastName { get; set; }

        public CustomerDetailModel CustomerDetail { get; set; }
    }

        public class CustomerDetailModel
        {
            public int Id { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

           
            public string Email { get; set; }
            
            public string Phone { get; set; }

            
            public string PrimaryAddress { get; set; }

            public string AlternateAddress { get; set; }

            
            public string City { get; set; }

            [MaxLength(15)]
            public string State { get; set; }

            
            public string PostalCode { get; set; }
            
            public string Country { get; set; }
        }
    
}
