using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class UsersTb
    {
        public UsersTb()
        {
            IdeaMembersTbs = new HashSet<IdeaMembersTb>();
        }

        public decimal MemberId { get; set; }
        public decimal UserName { get; set; }
        public decimal UserTypeId { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual MembersTb Member { get; set; }
        public virtual UserTypesTb UserType { get; set; }
        public virtual ICollection<IdeaMembersTb> IdeaMembersTbs { get; set; }
    }
}
