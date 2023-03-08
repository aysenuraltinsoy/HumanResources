using HR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
    public class AdvanceConfirmDTO
    {
        public Guid ID { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }

        public DateTime ReplyDate { get; set; } = DateTime.Now;

        public DateTime ApprovalDate { get; set;}

        public AdvanceType AdvanceType { get; set; }

    }
}
