using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class NotificationsTb
    {
        public decimal NotificationId { get; set; }
        public decimal ReceiverId { get; set; }
        public decimal CreatedBy { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public decimal TypeId { get; set; }
        public decimal Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual MembersTb CreatedByNavigation { get; set; }
        public virtual MembersTb Receiver { get; set; }
        public virtual NotificationTypeTb Type { get; set; }
    }
}
