using HR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
    public class ProcessAdvanceDTO
    {
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Approved;
    }
}
