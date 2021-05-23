using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class CertificateTb
    {
        public decimal MemberId { get; set; }
        public decimal CertificateId { get; set; }
        public decimal FieldId { get; set; }
        public decimal CertificateTypeId { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual CertificationTypesTb CertificateType { get; set; }
        public virtual FieldsTb Field { get; set; }
        public virtual MembersTb Member { get; set; }
    }
}
