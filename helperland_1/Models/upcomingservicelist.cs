using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helperland_1.Models
{
    public class upcomingservicelist
    {
        public int UserId { get; set; }    
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public int ServiceRequestId { get; set; }    
        public int ServiceId { get; set; }
        public string Comments { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public string ZipCode { get; set; }
        public decimal? ServiceHourlyRate { get; set; }
        public double ServiceHours { get; set; }
        public double? ExtraHours { get; set; }
        public decimal SubTotal { get; set; }
        public int? ServiceProviderId { get; set; }
        public DateTime? SpacceptedDate { get; set; }
        public bool? HasPets { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? HasIssue { get; set; }
        public bool? PaymentDone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
