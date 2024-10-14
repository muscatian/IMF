using IMF.DAL.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IMF.DAL.Models.Common;
using IMF.DAL.Models.HR;

namespace IMF.DAL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasOne(s => s.Created)
            .WithMany(g => g.EmployeeCreatedby)
            .HasForeignKey(s => s.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

            builder.HasOne(s => s.Modified)
            .WithMany(g => g.EmployeeModifiedby)
            .HasForeignKey(s => s.LastModifiedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

            builder.Property(a => a.CurrentBasic).HasPrecision(18, 3);
        }
    }
}
