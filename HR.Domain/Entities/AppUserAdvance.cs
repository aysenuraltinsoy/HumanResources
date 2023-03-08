using HR.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Domain.Entities
{
    public class AppUserAdvance: IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public DateTimeOffset? ReplyDate { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public Currency Currency { get; set; }
        public AdvanceType AdvanceType { get; set; }
        //-----
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        
    }
}
