using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR.Domain.Enum
{
    public enum Sector
    {     
        Custom,
        Production,
        Technology,
        [Display(Name = "Entertainment & Media")]
        EntertainmentAndMedia,
        Telecommunication,
        Retailer,
        Health,
        [Display(Name = "Transport and Logistics")]
        TransportationAndLogistics,
        [Display(Name = "Electricity and Infrastructure")]
        ElectricityAndInfrastructure,
        Chemical,
        Public,
        Construction,
        Other
    }
}
