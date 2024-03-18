using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(genre => genre.Name).HasMaxLength(100).IsRequired();



            //Seed Data
            builder.HasData(new Genre
            {
              Id = 1,
              CreatedDate = DateTime.Now,
              ModifiedDate = null,
              DeletedDate = null,
              Name = "Roman",
              Status = true,
            },
            new Genre
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Hikaye",
                Status = true,
            },
            new Genre
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Şiir",
                Status = true,
            },
            new Genre
            {
                Id = 4,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Fabl",
                Status = true,
            },
            new Genre
            {
                Id = 5,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Masal",
                Status = true,
            },
            new Genre
            {
                Id = 6,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Tiyatro",
                Status = true,
            },
            new Genre
            {
                Id = 7,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Deneme",
                Status = true,
            },
            new Genre
            {
                Id = 8,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Name = "Ansiklopedi",
                Status = true,
            });
        }
    }
}
