using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class IdeaPhaseTb
    {
        public IdeaPhaseTb()
        {
            CommitteTbs = new HashSet<CommitteTb>();
            IdeaAttachmentsTbs = new HashSet<IdeaAttachmentsTb>();
            IdeaMembersTbs = new HashSet<IdeaMembersTb>();
            ProjectTbs = new HashSet<ProjectTb>();
            SuperviserTbs = new HashSet<SuperviserTb>();
        }

        public decimal IdeaPhaseId { get; set; }
        public decimal TheBusinessModelCanvasId { get; set; }
        public decimal ProjectPhase { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime AnticipatedDate { get; set; }
        public decimal FieldId { get; set; }
        public decimal CreatedBy { get; set; }
        public decimal? Result { get; set; }
        public string Reason { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual FieldsTb Field { get; set; }
        public virtual CommitteReportsTb CommitteReportsTb { get; set; }
        public virtual TheBusinessModelCanvasTb TheBusinessModelCanvasTb { get; set; }
        public virtual ICollection<CommitteTb> CommitteTbs { get; set; }
        public virtual ICollection<IdeaAttachmentsTb> IdeaAttachmentsTbs { get; set; }
        public virtual ICollection<IdeaMembersTb> IdeaMembersTbs { get; set; }
        public virtual ICollection<ProjectTb> ProjectTbs { get; set; }
        public virtual ICollection<SuperviserTb> SuperviserTbs { get; set; }
    }
}
