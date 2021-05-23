using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class UserTypesTb
    {
        public UserTypesTb()
        {
            ProjMembersTbs = new HashSet<ProjMembersTb>();
            UsersTbs = new HashSet<UsersTb>();
        }

        public decimal UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ICollection<ProjMembersTb> ProjMembersTbs { get; set; }
        public virtual ICollection<UsersTb> UsersTbs { get; set; }
    }
}
