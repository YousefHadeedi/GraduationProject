using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class TheBusinessModelCanvasTb
    {
        public decimal IdeaPhaseId { get; set; }
        public string CompanyName { get; set; }
        public string KeyPartners { get; set; }
        public string KeyActivities { get; set; }
        public string ValueProposition { get; set; }
        public string CustomerRelationships { get; set; }
        public string CustomerSegments { get; set; }
        public string KeyResources { get; set; }
        public string Channels { get; set; }
        public string CostStructure { get; set; }
        public string RevenueStreams { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual IdeaPhaseTb IdeaPhase { get; set; }
    }
}
