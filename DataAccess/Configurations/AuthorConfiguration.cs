using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(author => author.Name).HasMaxLength(100).IsRequired();
            builder.Property(author => author.Surname).HasMaxLength(100).IsRequired();
        }
    }
}
