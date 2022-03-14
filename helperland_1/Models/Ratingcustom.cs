using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helperland_1.Models
{
    public class Ratingcustom
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ServiceId { get; set; }
        public int RatingId { get; set; }
        public decimal? Ratings { get; set; }
        public string Comments { get; set; }
        public DateTime RatingDate { get; set; }
        public decimal TotalCost { get; set; }
        public int? Status { get; set; }
        public int? ServiceProviderId { get; set; }
        public int ServiceRequestId { get; set; }
        public DateTime ServiceStartDate { get; set; }
    }
}
