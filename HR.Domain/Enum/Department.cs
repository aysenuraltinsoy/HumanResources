using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR.Domain.Enum
{
    public enum Department
    {
        [Display(Name = "Human Resources")]
        HumanResources =1,
        Engineer,
        IT
    }
}
