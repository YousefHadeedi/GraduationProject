using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class FinanceRequirementsTb
    {
        public FinanceRequirementsTb()
        {
            ReceiptVoucherAttachmentsTbs = new HashSet<ReceiptVoucherAttachmentsTb>();
            ReceivedRequirementAttachmentTbs = new HashSet<ReceivedRequirementAttachmentTb>();
            RequirementDescriptionAttachmentTbs = new HashSet<RequirementDescriptionAttachmentTb>();
        }

        public decimal ProjectId { get; set; }
        public decimal FinanceRequirementsId { get; set; }
        public decimal RequirementType { get; set; }
        public decimal CurrencyId { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeSpan RequestTime { get; set; }
        public decimal Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual CurrencyTb Currency { get; set; }
        public virtual ProjectTb Project { get; set; }
        public virtual ICollection<ReceiptVoucherAttachmentsTb> ReceiptVoucherAttachmentsTbs { get; set; }
        public virtual ICollection<ReceivedRequirementAttachmentTb> ReceivedRequirementAttachmentTbs { get; set; }
        public virtual ICollection<RequirementDescriptionAttachmentTb> RequirementDescriptionAttachmentTbs { get; set; }
    }
}
