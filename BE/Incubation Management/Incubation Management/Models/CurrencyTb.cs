using System;
using System.Collections.Generic;

#nullable disable

namespace Incubation_Management.Models
{
    public partial class CurrencyTb
    {
        public CurrencyTb()
        {
            FinanceRequirementsTbs = new HashSet<FinanceRequirementsTb>();
        }

        public decimal CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal CreatedBy { get; set; }

        public virtual ICollection<FinanceRequirementsTb> FinanceRequirementsTbs { get; set; }
    }
}
