using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class ProjectAttachmentsTb
    {
        public decimal ProjectId { get; set; }
        public decimal ProjectAttachmentId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ProjectTb Project { get; set; }
    }
}
