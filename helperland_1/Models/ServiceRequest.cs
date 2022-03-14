using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace helperland_1.Models
{
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            Ratings = new HashSet<Rating>();
            ServiceRequestAddresses = new HashSet<ServiceRequestAddress>();
            ServiceRequestExtras = new HashSet<ServiceRequestExtra>();
   
        }
        [NotMapped]
        public int extraId { get; set; }
        [NotMapped]
        public int AddId { get; set; }

        [NotMapped]
        public string Date { get; set; }

        [NotMapped]
        public int QualityOfService { get; set; }
        [NotMapped]
        public int Friendly { get; set; }
        [NotMapped]
        public int OnTimeArrival { get; set; }
        [NotMapped]
        public int Ratee { get; set; }

        [NotMapped]
        public string Time { get; set; }
        public int ServiceRequestId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }

        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime ServiceStartDate { get; set; }
        public string ZipCode { get; set; }
        public decimal? ServiceHourlyRate { get; set; }
        public double ServiceHours { get; set; }
        public double? ExtraHours { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal TotalCost { get; set; }
        public string Comments { get; set; }
        public string PaymentTransactionRefNo { get; set; }
        public bool? PaymentDue { get; set; }
        public int? ServiceProviderId { get; set; }
        public DateTime? SpacceptedDate { get; set; }
        public bool? HasPets { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public decimal? RefundedAmount { get; set; }
        public decimal? Distance { get; set; }
        public bool? HasIssue { get; set; }
        public bool? PaymentDone { get; set; }
        public Guid? RecordVersion { get; set; }

        public virtual User ServiceProvider { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<ServiceRequestAddress> ServiceRequestAddresses { get; set; }
        public virtual ICollection<ServiceRequestExtra> ServiceRequestExtras { get; set; }
    }
}
