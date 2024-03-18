using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(publisher => publisher.Name).HasMaxLength(100).IsRequired();

            builder.Property(publisher => publisher.Address).HasMaxLength(200).IsRequired();

            builder.Property(publisher => publisher.Phone).HasMaxLength(11).IsRequired();

            builder.Property(publisher => publisher.Email).HasMaxLength(100).IsRequired();
        }
    }
}
