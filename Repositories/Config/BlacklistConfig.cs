using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class BlacklistConfig : IEntityTypeConfiguration<Blacklist>
    {
        public void Configure(EntityTypeBuilder<Blacklist> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Reason)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(b => b.Date).IsRequired();
            builder.Property(b => b.ApplicantId).IsRequired();
        }
    }
}
