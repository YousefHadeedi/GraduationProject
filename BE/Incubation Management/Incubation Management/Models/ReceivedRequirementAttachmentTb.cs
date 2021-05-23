using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class ReceivedRequirementAttachmentTb
    {
        public decimal ProjectId { get; set; }
        public decimal FinanceRequirementsId { get; set; }
        public decimal ReceiptVoucherAttachmentId { get; set; }
        public decimal ReceivedRequirementAttachment { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual FinanceRequirementsTb FinanceRequirements { get; set; }
        public virtual ProjectTb Project { get; set; }
        public virtual ReceiptVoucherAttachmentsTb ReceiptVoucherAttachment { get; set; }
    }
}
