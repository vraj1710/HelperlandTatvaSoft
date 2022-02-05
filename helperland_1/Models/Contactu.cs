using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace helperland_1.Models
{
    public partial class Contactu
    {

        public int Contactusid { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
