using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace helperland_1.Models
{
    public partial class ContactU
    {
        public int Contactusid { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[6789][0-9]{9}$", ErrorMessage = "Enter a valid mobile number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public ContactU()
        {
            this.CreatedOn = DateTime.UtcNow;

        }
        public DateTime? CreatedOn { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int ContactUsId { get; set; }
        public string UploadFileName { get; set; }
        public int? CreatedBy { get; set; }
        public string FileName { get; set; }
        
    }
}
