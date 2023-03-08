﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR.Domain.Enum
{
    public enum ApprovalStatus
    {
        [Display(Name = "Awaiting Approval")]
        AwaitingApproval,
        Approved,
        Rejection,
        Cancelled

    }
}
