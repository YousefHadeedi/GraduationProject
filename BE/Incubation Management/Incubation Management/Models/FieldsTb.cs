using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class FieldsTb
    {
        public FieldsTb()
        {
            CertificateTbs = new HashSet<CertificateTb>();
            ExperiencesTbs = new HashSet<ExperiencesTb>();
            IdeaPhaseTbs = new HashSet<IdeaPhaseTb>();
            ProjectTbs = new HashSet<ProjectTb>();
            ResearchsTbs = new HashSet<ResearchsTb>();
        }

        public decimal FieldId { get; set; }
        public string FieldName { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ICollection<CertificateTb> CertificateTbs { get; set; }
        public virtual ICollection<ExperiencesTb> ExperiencesTbs { get; set; }
        public virtual ICollection<IdeaPhaseTb> IdeaPhaseTbs { get; set; }
        public virtual ICollection<ProjectTb> ProjectTbs { get; set; }
        public virtual ICollection<ResearchsTb> ResearchsTbs { get; set; }
    }
}
