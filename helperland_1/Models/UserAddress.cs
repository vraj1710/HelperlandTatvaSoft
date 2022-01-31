﻿using System;
using System.Collections.Generic;

#nullable disable

namespace helperland_1.Models
{
    public partial class UserAddress
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int? Type { get; set; }

        public virtual User User { get; set; }
    }
}