using HR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HR.Infrastructure.EntityTypeConfiguration
{
    public class AppUserAdvanceConfig :BaseEntityConfig<AppUserAdvance>
    {
        public override void Configure(EntityTypeBuilder<AppUserAdvance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.AppUserAdvances)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);
                
                
            base.Configure(builder);

        }
    }
}
