using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class CommitteReportsTb
    {
        public decimal IdeaPhaseId { get; set; }
        public decimal CommitteReportId { get; set; }
        public string ReportDescription { get; set; }
        public TimeSpan ReportTime { get; set; }
        public DateTime ReportDate { get; set; }
        public string Location { get; set; }
        public string Reason { get; set; }
        public decimal Result { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual IdeaPhaseTb IdeaPhase { get; set; }
    }
}
