using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class ProjMembersTb
    {
        public decimal ProjectId { get; set; }
        public decimal MemberId { get; set; }
        public decimal UserTypeId { get; set; }
        public decimal IsActive { get; set; }
        public string JobTitle { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual MembersTb Member { get; set; }
        public virtual ProjectTb Project { get; set; }
        public virtual UserTypesTb UserType { get; set; }
    }
}
