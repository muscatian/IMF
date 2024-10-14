using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IMF.DAL.Models.HR;

namespace IMF.DAL.Configuration
{
    public class DocumentsConfiguration : IEntityTypeConfiguration<Documents>
    {
        public void Configure(EntityTypeBuilder<Documents> builder)
        {
            builder.HasOne(s => s.Created)
            .WithMany(g => g.DocumentCreatedby)
            .HasForeignKey(s => s.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

            builder.HasOne(s => s.Modified)
            .WithMany(g => g.DocumentModifiedby)
            .HasForeignKey(s => s.LastModifiedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
        }
    }
}
