using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace helperland_1.Models
{
    public partial class User
    {
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password",ErrorMessage = "password and confirm password do not match")]
        public string confirmpassword { get; set; }

        [Required]
        public string Mobile { get; set; }
        public int UserTypeId { get; set; }
    }
}
