using HR.Domain.Entities;
using HR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.VMs
{
    public class UserAdvanceVM
    {
        public Guid Id { get; set; }
        public DateTimeOffset RequestDate { get; set; } = DateTime.Now;
        public DateTimeOffset ReplyDate { get; set; }
        public DateTimeOffset ApprovalDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.AwaitingApproval;
        public Currency Currency { get; set; }
        public AdvanceType AdvanceType { get; set; }
        public AppUser AppUser { get; set; }

    }
}
