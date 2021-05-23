using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class ExperiencesTb
    {
        public decimal MemberId { get; set; }
        public decimal ExperienceId { get; set; }
        public string CompenyName { get; set; }
        public decimal FieldId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }

        public virtual FieldsTb Field { get; set; }
        public virtual MembersTb Member { get; set; }
    }
}
