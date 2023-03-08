using HR.Domain.Entities;
using HR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
    public class RequestAdvanceDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset RequestDate { get; set; } = DateTime.Now;
        public DateTimeOffset? ReplyDate { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.AwaitingApproval;
        public Currency Currency { get; set; }
        public AdvanceType AdvanceType { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
