
using HR.Domain.Entities;
using HR.Domain.SeedData;
using HR.Infrastructure.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Infrastructure.Context
{
    public class HumanResourcesDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserCliams,AppUserRole,AppUserLogin,AppRoleClaims,AppUserToken>
    {
        public HumanResourcesDbContext(DbContextOptions<HumanResourcesDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			
		   SeedData.Seed(modelBuilder);
		
			
            modelBuilder.ApplyConfiguration(new AppUserConfig());
           
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUserAdvance> AppUserAdvance { get; set; }    
        public DbSet<AppCompany> AppCompany { get; set; }
    }
}
