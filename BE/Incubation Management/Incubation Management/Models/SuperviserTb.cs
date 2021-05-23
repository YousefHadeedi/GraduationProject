using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class SuperviserTb
    {
        public decimal IdeaPhaseId { get; set; }
        public decimal SuperviserId { get; set; }
        public decimal MemberId { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual IdeaPhaseTb IdeaPhase { get; set; }
        public virtual MembersTb Member { get; set; }
    }
}
