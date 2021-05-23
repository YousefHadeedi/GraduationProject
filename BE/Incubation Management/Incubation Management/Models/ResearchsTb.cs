using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class ResearchsTb
    {
        public decimal MemberId { get; set; }
        public decimal ResearchId { get; set; }
        public string ResearchName { get; set; }
        public decimal FieldId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual FieldsTb Field { get; set; }
        public virtual MembersTb Member { get; set; }
    }
}
