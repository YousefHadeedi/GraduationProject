using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class ProjectDetailsTb
    {
        public decimal ProjectId { get; set; }
        public string ExcutiveSummery { get; set; }
        public string CompanyDescription { get; set; }
        public string MarketAnalysis { get; set; }
        public string ServiceOrProduct { get; set; }
        public string MarketingPlan { get; set; }
        public string FinancialsProjections { get; set; }
        public string FundingRequirements { get; set; }
        public string ManagementTeam { get; set; }
        public string ReviewSchedule { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ProjectTb Project { get; set; }
    }
}
