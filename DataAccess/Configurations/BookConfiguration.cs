using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(book=>book.Name).HasMaxLength(100).IsRequired();

            builder.Property(book => book.TotalStock).HasMaxLength(200).IsRequired();

            builder.Property(book => book.InStock).HasMaxLength(200).IsRequired();

            builder.Property(book => book.Section).HasMaxLength(100).IsRequired();

            

            
        }
    }
}
