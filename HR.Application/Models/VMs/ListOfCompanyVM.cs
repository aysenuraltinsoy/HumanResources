using HR.Domain.Entities;
using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HR.Application.Models.VMs
{
	public class ListOfCompanyVM
    {
		public List<AppCompany> Companies { get; set; }  // Şirketlerin listesi
		public int TotalCount { get; set; }           // Toplam şirket sayısı
		public int PageSize { get; set; }             // Sayfa başına şirket sayısı
		public int CurrentPage { get; set; }          // Mevcut sayfa numarası
	}
}
