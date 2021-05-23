using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class MeetingReportsTb
    {
        public decimal ProjectId { get; set; }
        public decimal MeetingReportId { get; set; }
        public string MeetingTitle { get; set; }
        public TimeSpan? ReportTime { get; set; }
        public DateTime ReportDate { get; set; }
        public string Location { get; set; }
        public string MeetingSummary { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ProjectTb Project { get; set; }
    }
}
