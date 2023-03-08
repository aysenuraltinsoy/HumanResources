using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
	public class TakeNewPasswordDTO
	{
		public string CurrentPassword { get; set; }
		public string Password { get; set; }
		[Compare("Password",ErrorMessage ="Password does not match")]
		public string ConfirmPassword { get; set; }

	}
}
