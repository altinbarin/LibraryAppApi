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


            //Seed Data
            builder.HasData(
                new Book
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "Kürk Mantolu Madonna",
                    TotalStock = 5,
                    InStock = 5,
                    Section = "113",
                    PublisherId = 1,
                    AuthorId = 3,
                    GenreId = 1,
                },
                new Book
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "Güz Bitiği",
                    TotalStock = 2,
                    InStock = 2,
                    Section = "113",
                    PublisherId = 2,
                    AuthorId = 1,
                    GenreId = 3,
                },
                new Book
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "On Üç Günün Mektupları",
                    TotalStock = 1,
                    InStock = 1,
                    Section = "113",
                    PublisherId = 1,
                    AuthorId = 1,
                    GenreId = 3,
                },
                new Book
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "Günübirlik",
                    TotalStock = 1,
                    InStock = 1,
                    Section = "113",
                    PublisherId = 2,
                    AuthorId = 1,
                    GenreId = 3,
                },
                new Book
                {
                    Id = 5,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "Üvercinka",
                    TotalStock = 1,
                    InStock = 1,
                    Section = "113",
                    PublisherId = 2,
                    AuthorId = 1,
                    GenreId = 3,
                },
                new Book
                {
                    Id = 6,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "72. Koğuş",
                    TotalStock = 3,
                    InStock = 3,
                    Section = "113",
                    PublisherId = 5,
                    AuthorId = 2,
                    GenreId = 1
                },
                new Book
                {
                    Id = 7,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "Tersine Dünya",
                    TotalStock = 1,
                    InStock = 1,
                    Section = "113",
                    PublisherId = 5,
                    AuthorId = 2,
                    GenreId = 1
                },
                new Book
                {
                    Id = 8,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "Percy Jackson",
                    TotalStock = 12,
                    InStock = 12,
                    Section = "110",
                    PublisherId = 3,
                    AuthorId = 2,
                    GenreId = 1
                },
                new Book
                {
                    Id = 9,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "1919'dan Günümüze Türkiye",
                    TotalStock = 19,
                    InStock = 19,
                    Section = "110",
                    PublisherId = 6,
                    AuthorId = 6,
                    GenreId = 7
                },
                new Book
                {
                    Id = 10,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "Yüzüklerin Efendisi",
                    TotalStock = 1,
                    InStock = 1,
                    Section = "110",
                    PublisherId = 4,
                    AuthorId = 5,
                    GenreId = 1
                },
                new Book
                {
                    Id = 11,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = true,
                    Name = "La Fontaine Masalları",
                    TotalStock = 1,
                    InStock = 1,
                    Section = "109",
                    PublisherId = 3,
                    AuthorId = 6,
                    GenreId = 4
                }
                );

            
        }
    }
}
