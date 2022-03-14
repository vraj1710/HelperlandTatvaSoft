using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helperland_1.Models
{
    public class blockcustom
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public int? TargetUserId { get; set; }
        public bool? IsBlocked { get; set; }
    }
}
