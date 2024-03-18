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


            //Seed Data
            builder.HasData(new Publisher
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                ModifiedDate = null,
                Status = true,
                Name = "Everest",
                Address = "İstanbul",
                Phone = "02121234567",
                Email = "everest@mail.com"
            },
            new Publisher
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                ModifiedDate = null,
                Status = true,
                Name = "Doğan Kitap",
                Address = "İstanbul",
                Phone = "02121234567",
                Email = "dogan@gmail.com"
            },
            new Publisher
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                ModifiedDate = null,
                Status = true,
                Name = "İş Bankası",
                Address = "İstanbul",
                Phone = "02121234567",
                Email = "isbankasi@mail.com",
            },
            new Publisher
            {
                Id = 4,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                ModifiedDate = null,
                Status = true,
                Name = "Yapı Kredi",
                Address = "İstanbul",
                Phone = "02121234567",
                Email = "yapikredi@mail.com"
            },
            new Publisher
            {
                Id = 5,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                ModifiedDate = null,
                Status = true,
                Name = "Timaş",
                Address = "İstanbul",
                Phone = "02121234567",
                Email = "timas@mail.com"
            },
            new Publisher
            {
                Id = 6,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                ModifiedDate = null,
                Status = true,
                Name = "Tubitak",
                Address = "Ankara",
                Phone = "03121234567",
                Email = "tubitak@mail.com"
            });
        }
    }
}
