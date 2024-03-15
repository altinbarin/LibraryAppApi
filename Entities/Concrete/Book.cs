using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public int TotalStock { get; set; }
        public int InStock { get; set; }
        public string Section { get; set; }


        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }


        //public string Image { get; set; }
    }
}
