using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class CertificationTypesTb
    {
        public CertificationTypesTb()
        {
            CertificateTbs = new HashSet<CertificateTb>();
        }

        public decimal CertificationTypeId { get; set; }
        public string CertificationTypeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ICollection<CertificateTb> CertificateTbs { get; set; }
    }
}
