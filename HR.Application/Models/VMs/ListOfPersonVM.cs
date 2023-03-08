using HR.Domain.Entities;
using HR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.VMs
{
	public class ListOfPersonVM
	{
		public List<AppUser> Personnels { get; set; }  // Personellerin listesi
		public int TotalCount { get; set; }           // Toplam personel sayısı
		public int PageSize { get; set; }             // Sayfa başına personel sayısı
		public int CurrentPage { get; set; }          // Mevcut sayfa numarası

	}
}
