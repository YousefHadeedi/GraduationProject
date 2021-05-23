using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class MembersTb
    {
        public MembersTb()
        {
            CertificateTbs = new HashSet<CertificateTb>();
            CommitteTbs = new HashSet<CommitteTb>();
            ExperiencesTbs = new HashSet<ExperiencesTb>();
            NotificationsTbCreatedByNavigations = new HashSet<NotificationsTb>();
            NotificationsTbReceivers = new HashSet<NotificationsTb>();
            ProjMembersTbs = new HashSet<ProjMembersTb>();
            ResearchsTbs = new HashSet<ResearchsTb>();
            SuperviserTbs = new HashSet<SuperviserTb>();
        }

        public decimal MemberId { get; set; }
        public string MemberName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }
        public decimal IsActivae { get; set; }
        public string ContactPersonName { get; set; }
        public string Address { get; set; }

        public virtual UsersTb UsersTb { get; set; }
        public virtual ICollection<CertificateTb> CertificateTbs { get; set; }
        public virtual ICollection<CommitteTb> CommitteTbs { get; set; }
        public virtual ICollection<ExperiencesTb> ExperiencesTbs { get; set; }
        public virtual ICollection<NotificationsTb> NotificationsTbCreatedByNavigations { get; set; }
        public virtual ICollection<NotificationsTb> NotificationsTbReceivers { get; set; }
        public virtual ICollection<ProjMembersTb> ProjMembersTbs { get; set; }
        public virtual ICollection<ResearchsTb> ResearchsTbs { get; set; }
        public virtual ICollection<SuperviserTb> SuperviserTbs { get; set; }
    }
}
