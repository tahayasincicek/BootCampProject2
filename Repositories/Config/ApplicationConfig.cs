using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ApplicationConfig : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ApplicationState).HasConversion<int>();
            builder.HasOne(a => a.Bootcamp)
                   .WithMany(b => b.Applications)
                   .HasForeignKey(a => a.BootcampId);
        }
    }
}
