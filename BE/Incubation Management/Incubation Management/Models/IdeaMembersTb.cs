using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class IdeaMembersTb
    {
        public decimal IdeaPhaseId { get; set; }
        public decimal IdeaMemberId { get; set; }
        public decimal UserId { get; set; }
        public string JobTitle { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public decimal IsActive { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual IdeaPhaseTb IdeaPhase { get; set; }
        public virtual UsersTb User { get; set; }
    }
}
