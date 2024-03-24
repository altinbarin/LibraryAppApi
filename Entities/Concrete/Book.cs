using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public int TotalStock { get; set; }
        public int InStock { get; set; }
        public string Section { get; set; }


        public int GenreId { get; set; }

        public int PublisherId { get; set; }

        public int AuthorId { get; set; }


    }
}
