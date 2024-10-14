using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IMF.DAL.Models.HR;

namespace IMF.DAL.Configuration
{
    public class PayScaleConfiguration : IEntityTypeConfiguration<PayScale>
    {
        public void Configure(EntityTypeBuilder<PayScale> builder)
        {
            builder.HasOne(s => s.Created)
            .WithMany(g => g.PayScaleCreatedby)
            .HasForeignKey(s => s.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

            builder.HasOne(s => s.Modified)
            .WithMany(g => g.PayScaleModifiedby)
            .HasForeignKey(s => s.LastModifiedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
        }
    }
}
