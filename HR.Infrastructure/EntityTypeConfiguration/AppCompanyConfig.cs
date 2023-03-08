using HR.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Infrastructure.EntityTypeConfiguration
{
    public class AppCompanyConfig : BaseEntityConfig<AppCompany>
    {
        public override void Configure(EntityTypeBuilder<AppCompany> builder)
        {
            builder.HasKey(x => x.AppCompanyID);
            builder.Property(x=>x.AppCompanyID).IsRequired(true);
            builder.HasMany(x => x.Personnels).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);


            base.Configure(builder);
        }
    }
}
