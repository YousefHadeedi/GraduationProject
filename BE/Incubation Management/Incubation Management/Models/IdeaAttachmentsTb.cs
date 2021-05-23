using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class IdeaAttachmentsTb
    {
        public decimal IdeaPhaseId { get; set; }
        public decimal AttachmentId { get; set; }
        public string FileName { get; set; }
        public string Descriptoin { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual IdeaPhaseTb IdeaPhase { get; set; }
    }
}
