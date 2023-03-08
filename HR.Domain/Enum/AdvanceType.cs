using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR.Domain.Enum
{
    public enum AdvanceType
    {
        [Display(Name = "Individual Demand")]
        IndividualDemand,
        [Display(Name = "Corporate Demand")]
        CorporateDemand,
    }
}
