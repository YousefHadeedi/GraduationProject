using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class NotificationTypeTb
    {
        public NotificationTypeTb()
        {
            NotificationsTbs = new HashSet<NotificationsTb>();
        }

        public decimal NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ICollection<NotificationsTb> NotificationsTbs { get; set; }
    }
}
