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


            //Seed Data
            builder.HasData(new Author
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Cemal",
                Surname = "Süreya",
                Status = true,
            },
            new Author
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Orhan",
                Surname = "Kemal",
                Status = true,
            },
            new Author
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Sabahattin",
                Surname = "Ali",
                Status = true,
            },
            new Author
            {
                Id = 4,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Rick",
                Surname = "Riordan",
                Status = true,
            },
            new Author
            {
                Id = 5,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "J.K.",
                Surname = "Rowling",
                Status = true,
            },
            new Author
            {
                Id = 6,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Anonim",
                Surname = "Anonim",
                Status = true,
            });
        }
    }
}
