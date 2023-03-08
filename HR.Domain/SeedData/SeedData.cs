using HR.Domain.Entities;
using HR.Domain.Enum;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR.Domain.SeedData
{
	public static class SeedData
	{

		public static void Seed(this ModelBuilder modelBuilder)
		{
			List<AppRole> roles = new List<AppRole>() {
				new AppRole {Id=Guid.NewGuid(), Name = "Personnel", NormalizedName = "PERSONNEL"  },
				new AppRole {Id=Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
				new AppRole {Id = Guid.NewGuid(), Name = "Manager", NormalizedName = "MANAGER" }
			};
			modelBuilder.Entity<AppRole>().HasData(roles);
			List<AppUser> users = new List<AppUser>() {
				new AppUser {
					Id=Guid.NewGuid(),
					UserName="RamazanY",
					NormalizedUserName="RAMAZANY",
                    //PasswordHash="12345",
                    Name = "Ramazan",
					Surname="YAYLALI",
					BirthDate= new DateTime(1997,01,25),
					PlaceOfBirth="Acıpayam",
					Salary=10000,
					IdentityNumber="41485012455",
					PhoneNumber=5365867759,
					ImagePath="/img/userspic/Ramazan.jpg",
					StartingDate=new DateTime(2022,06,12),
					EndingDate=new DateTime(2022,12,05),
					Address="Yanişehir mah. 18 sok no:41 daire:4, Denizli/Merkezefendi",
					IsActive=false,
					CreateDate=DateTime.Now,
					Email = "ramazan.yaylali@bilgeadamboost.com",
					NormalizedEmail="ramazan.yaylalı@bılgeadamboost.com".ToUpper(),
					SecurityStamp=Guid.NewGuid().ToString(),
					Department = Department.Engineer,
					Sector = Sector.Public,
				},
				new AppUser {
					Id=Guid.NewGuid(),
					UserName="HazelC",
					NormalizedUserName="HAZELC",
                    //PasswordHash="12345",
                    Name = "Hazel",
					Surname="ÇALKAR",
					Salary=13000,
					BirthDate= new DateTime(1988,05,08),
					PlaceOfBirth="İzmir",
					IdentityNumber="31354697822",
					PhoneNumber=5365867759,
					ImagePath=null,
					StartingDate=new DateTime(2020,02,25),
					EndingDate=null,
					Address="Yalı mahallesi Caher Dudayev Bulvarı No:107 D:B, İzmir/Karşıyaka ",
					IsActive=true,
					CreateDate=DateTime.Now,
					Email = "hazel.calkar@bilgeadamboost.com",
					NormalizedEmail="hazel.calkar@bılgeadamboost.com".ToUpper(),
					SecurityStamp=Guid.NewGuid().ToString(),
					Department = Department.IT,
					Sector = Sector.Public
				},
				 new AppUser {
					Id=Guid.NewGuid(),
					UserName="AysenurA",
					NormalizedUserName="AYSENURA",
                    //PasswordHash="12345",
                    Name = "Ayşenur",
					Surname="ALTINSOY",
					Salary=14000,
					BirthDate= new DateTime(1982,09,09),
					PlaceOfBirth="İzmir",
					IdentityNumber="78953246782",
					PhoneNumber=5365867759,
					ImagePath=null,
					StartingDate=new DateTime(2019,03,28),
					EndingDate=null,
					Address="Bostanlı mahallesi Cengiz Kocatoros Sokağı No: 85/A, İzmir/Karşıyaka ",
					IsActive=true,
					CreateDate=DateTime.Now,
					Email = "aysenur.altınsoy@bilgeadamboost.com",
					NormalizedEmail="aysenur.altınsoy@bılgeadamboost.com".ToUpper(),
					SecurityStamp=Guid.NewGuid().ToString(),
					Department = Department.IT,
					Sector = Sector.Public
				},
				 new AppUser {
					Id=Guid.NewGuid(),
					UserName="SerkanT",
					NormalizedUserName="SERKANT",
                    //PasswordHash="12345",
                    Name = "Serkan",
					Surname="TEMİZ",
					Salary=14000,
					BirthDate= new DateTime(1995,05,07),
					PlaceOfBirth="İstanbul",
					IdentityNumber="19637426548",
					PhoneNumber=5425324892,
					ImagePath=null,
					StartingDate=new DateTime(2020,02,25),
					EndingDate=null,
					Address="Caferağa mahallesi Mühürdar Cd. No:76 kat:5, İstanbul/Sarıyer",
					IsActive=true,
					CreateDate=DateTime.Now,
					Email = "serkan.temiz@bilgeadamboost.com",
					 NormalizedEmail="serkan.temız@bılgeadamboost.com".ToUpper(),
					SecurityStamp=Guid.NewGuid().ToString(),
					Department = Department.Engineer,
					Sector = Sector.ElectricityAndInfrastructure
				},
				 new AppUser {
					Id=Guid.NewGuid(),
					UserName="FatihB",
					NormalizedUserName="FATIHB",
                    //PasswordHash="12345",
                    Name = "Fatih",
					Surname="BAG",
					Salary=13000,
					BirthDate= new DateTime(2000,01,01),
					PlaceOfBirth="Denizli",
					IdentityNumber="12312345678",
					PhoneNumber=5318700685,
					ImagePath=null,
					StartingDate=new DateTime(2021,07,27),
					EndingDate=new DateTime(2023,01,18),
					Address="Cumhuriyet mah. 5034 sok no:2 daire:3,Denizli/Pamukkale",
					IsActive=false,
					CreateDate=DateTime.Now,
					Email = "fatih.bag@bilgeadamboost.com",
					NormalizedEmail="fatıh.bag@bılgeadamboost.com".ToUpper(),
					SecurityStamp=Guid.NewGuid().ToString(),
					Department = Department.Engineer,
					Sector = Sector.TransportationAndLogistics
				}

			};
			modelBuilder.Entity<AppUser>().HasData(users);
			var passwordHasher = new PasswordHasher<AppUser>();
			users[0].PasswordHash = passwordHasher.HashPassword(users[0], "1234");
			users[1].PasswordHash = passwordHasher.HashPassword(users[1], "1234");
			users[2].PasswordHash = passwordHasher.HashPassword(users[2], "1234");
			users[3].PasswordHash = passwordHasher.HashPassword(users[3], "1234");
			users[4].PasswordHash = passwordHasher.HashPassword(users[4], "1234");
			List<AppUserRole> userRoles = new List<AppUserRole>();
			userRoles.Add(new AppUserRole
			{
				UserId = users[0].Id,
				RoleId = roles.First(q => q.Name == "Personnel").Id
			});
			userRoles.Add(new AppUserRole
			{
				UserId = users[1].Id,
				RoleId = roles.First(q => q.Name == "Personnel").Id
			});
			userRoles.Add(new AppUserRole
			{
				UserId = users[2].Id,
				RoleId = roles.First(q => q.Name == "Personnel").Id
			});
			userRoles.Add(new AppUserRole
			{
				UserId = users[3].Id,
				RoleId = roles.First(q => q.Name == "Admin").Id
			});
			userRoles.Add(new AppUserRole
			{
				UserId = users[4].Id,
				RoleId = roles.First(q => q.Name == "Admin").Id
			});
			#region Example
			//userRoles.Add(new AppUserRole
			//{
			//    UserId = users[1].Id,
			//    RoleId = roles.First(q => q.Name == "Coach").Id
			//});
			//userRoles.Add(new AppUserRole
			//{
			//    UserId = users[2].Id,
			//    RoleId = roles.First(q => q.Name == "Swimmer").Id
			//});
			//userRoles.Add(new AppUserRole
			//{
			//    UserId = users[3].Id,
			//    RoleId = roles.First(q => q.Name == "Visitor").Id
			//});
			#endregion
			modelBuilder.Entity<AppUserRole>().HasData(userRoles);
		}

	}
}

