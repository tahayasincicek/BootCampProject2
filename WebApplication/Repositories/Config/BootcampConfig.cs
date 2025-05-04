using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class BootcampConfig : IEntityTypeConfiguration<Bootcamp>
    {
        public void Configure(EntityTypeBuilder<Bootcamp> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.InstructorId).IsRequired();
            builder.Property(b => b.StartDate).IsRequired();
            builder.Property(b => b.EndDate).IsRequired();
            builder.Property(b => b.BootcampState)
                   .HasConversion<int>()
                   .IsRequired();

            builder.HasMany(b => b.Applications)
                   .WithOne(a => a.Bootcamp)
                   .HasForeignKey(a => a.BootcampId);
        }
    }
}
