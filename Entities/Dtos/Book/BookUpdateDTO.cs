using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Book
{
    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalStock { get; set; }
        public int InStock { get; set; }
        public string Section { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }


        //düzenlenecek

        //public int GenreId { get; set; }
        //public int PublisherId { get; set; }
        //public int AuthorId { get; set; }
    }
}
