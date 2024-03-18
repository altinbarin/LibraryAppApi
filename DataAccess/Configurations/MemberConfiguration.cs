using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TCKNO).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(250).IsRequired();


            //Seed Data
            builder.HasData(new Member
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Status = true,
                Name = "Furkan",
                Surname = "Altınbarın",
                TCKNO = "20890834938",
                Address = "İstanbul, Kadıköy",
                Email = "furkanaltinbarin@gmail.com",
                Phone = "05431768274",
            },
            new Member
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Status = true,
                Name = "Mehmet",
                Surname = "Çatmakaşlı",
                TCKNO = "55871434614",
                Address = "İstanbul, Cevizlibağ",
                Email = "mehmetcatmakasli@mail.com",
                Phone = "05363235378"
            },
            new Member
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Status = true,
                Name = "Ahmet",
                Surname = "Yılmaz",
                TCKNO = "70726402020",
                Address = "İstanbul, Üsküdar",
                Email = "ahmetyilmaz@gmail.com",
                Phone = "05363235375"
            },
            new Member
            {
                Id = 4,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Status = true,
                Name = "Ayşe",
                Surname = "Yılmaz",
                TCKNO = "20697468440",
                Address = "İstanbul, Kartal",
                Email = "ayseyilmaz@gmail.com",
                Phone = "05361031245"
            },
            new Member
            {
                Id = 5,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                Status = true,
                Name = "Fatma",
                Surname = "Kartal",
                TCKNO = "41354126398",
                Email = "fatmakartal@gmail.com",
                Phone = "05361031245",
                Address = "İstanbul, Avcılar"
            }
            );
        }
    }
}
