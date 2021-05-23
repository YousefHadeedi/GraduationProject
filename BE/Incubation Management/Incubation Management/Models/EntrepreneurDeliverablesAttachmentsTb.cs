using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class EntrepreneurDeliverablesAttachmentsTb
    {
        public decimal ProjectId { get; set; }
        public decimal DeliverableId { get; set; }
        public decimal AttachmentId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual EntrepreneurDeliverablesTb Deliverable { get; set; }
        public virtual ProjectTb Project { get; set; }
    }
}
