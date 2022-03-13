using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Core.Entities.Concrete
{
    public class ShippingDetails
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string  LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string  Address { get; set; }

        [Required]
        [Range(15,75)] // 15, ile 75 yasları arasında değer girecektir.
        public int Age { get; set; }
    }
}
