using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class DeliverablesTb
    {
        public decimal ProjectId { get; set; }
        public decimal DeliverableId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Status { get; set; }
        public decimal IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ProjectTb Project { get; set; }
    }
}
