using HR.Domain.Entities;
using HR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.VMs
{
	public class AdvanceListVM
	{
		public Guid ID { get; set; }
		public string Description { get; set; }
		public decimal Amount { get; set; }
		public Currency Currency { get; set; }
		public ApprovalStatus ApprovalStatus { get; set; }
		public AdvanceType AdvanceType { get; set; }
		public DateTimeOffset RequestDate { get; set; }
		public DateTimeOffset? ReplyDate { get; set; }

		public DateTimeOffset? ApprovalDate { get; set; }

		public virtual AppUser AppUser { get; set; }


	}
}
