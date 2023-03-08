using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDisplayName(this Enum enumValue)
		{
			var member = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
			if (member == null)
			{
				return enumValue.ToString();
			}

			var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
			if (displayAttribute == null)
			{
				return enumValue.ToString();
			}

			return displayAttribute.GetName();
		}
	}
}
