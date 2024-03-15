using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BooksOnHold:BaseEntity
    {
        public Member Member { get; set; }
        public int MemberId { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }

        public DateTime HoldDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        //30 günü geçen kitaplar için ücretlendirme yapılacak
        //25'inci ve 30'uncu günlerde mail atılacak
    }
}
