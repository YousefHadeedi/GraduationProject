using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class ProjectTb
    {
        public ProjectTb()
        {
            DeliverablesTbs = new HashSet<DeliverablesTb>();
            EntrepreneurDeliverablesAttachmentsTbs = new HashSet<EntrepreneurDeliverablesAttachmentsTb>();
            EntrepreneurDeliverablesTbs = new HashSet<EntrepreneurDeliverablesTb>();
            FinanceRequirementsTbs = new HashSet<FinanceRequirementsTb>();
            MeetingReportsTbs = new HashSet<MeetingReportsTb>();
            ProjMembersTbs = new HashSet<ProjMembersTb>();
            ProjectAttachmentsTbs = new HashSet<ProjectAttachmentsTb>();
            ReceiptVoucherAttachmentsTbs = new HashSet<ReceiptVoucherAttachmentsTb>();
            ReceivedRequirementAttachmentTbs = new HashSet<ReceivedRequirementAttachmentTb>();
            RequirementDescriptionAttachmentTbs = new HashSet<RequirementDescriptionAttachmentTb>();
        }

        public decimal ProjectId { get; set; }
        public decimal IdeaPhaseId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public decimal FieldId { get; set; }
        public decimal ProjectStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }
        public DateTime AnticipatedDate { get; set; }
        public DateTime? ActualDate { get; set; }

        public virtual FieldsTb Field { get; set; }
        public virtual IdeaPhaseTb IdeaPhase { get; set; }
        public virtual ProjectDetailsTb ProjectDetailsTb { get; set; }
        public virtual ICollection<DeliverablesTb> DeliverablesTbs { get; set; }
        public virtual ICollection<EntrepreneurDeliverablesAttachmentsTb> EntrepreneurDeliverablesAttachmentsTbs { get; set; }
        public virtual ICollection<EntrepreneurDeliverablesTb> EntrepreneurDeliverablesTbs { get; set; }
        public virtual ICollection<FinanceRequirementsTb> FinanceRequirementsTbs { get; set; }
        public virtual ICollection<MeetingReportsTb> MeetingReportsTbs { get; set; }
        public virtual ICollection<ProjMembersTb> ProjMembersTbs { get; set; }
        public virtual ICollection<ProjectAttachmentsTb> ProjectAttachmentsTbs { get; set; }
        public virtual ICollection<ReceiptVoucherAttachmentsTb> ReceiptVoucherAttachmentsTbs { get; set; }
        public virtual ICollection<ReceivedRequirementAttachmentTb> ReceivedRequirementAttachmentTbs { get; set; }
        public virtual ICollection<RequirementDescriptionAttachmentTb> RequirementDescriptionAttachmentTbs { get; set; }
    }
}
