using IMF.DAL.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IMF.DAL.Models.Common;

namespace IMF.DAL.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasOne(s => s.Created)
            .WithMany(g => g.CompanyCreatedby)
            .HasForeignKey(s => s.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

            builder.HasOne(s => s.Modified)
            .WithMany(g => g.CompanyModifiedby)
            .HasForeignKey(s => s.LastModifiedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
        }
    }
}
