using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IMF.DAL.Models.HR;

namespace IMF.DAL.Configuration
{
    public class JobHistoryConfiguration : IEntityTypeConfiguration<JobHistory>
    {
        public void Configure(EntityTypeBuilder<JobHistory> builder)
        {
            builder.HasOne(s => s.Created)
            .WithMany(g => g.JobHistoryCreatedby)
            .HasForeignKey(s => s.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

            builder.HasOne(s => s.Modified)
            .WithMany(g => g.JobHistoryModifiedby)
            .HasForeignKey(s => s.LastModifiedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
        }
    }
}
