﻿using System;
using System.Collections.Generic;

#nullable disable

namespace helperland_1.Models
{
    public partial class ServiceRequestExtra
    {
        public int ServiceRequestExtraId { get; set; }
        public int ServiceRequestId { get; set; }
        public int ServiceExtraId { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
