using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class BorrowedBook:BaseEntity
    {
        public Member Member { get; set; }
        public int MemberId { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }

        public DateTime BorrowDate { get; set; }=DateTime.Now;
        public DateTime? ReturnDate { get; set; }

        //30 günü geçen kitaplar için ücretlendirme yapılacak
        //25'inci ve 30'uncu günlerde mail atılacak
    }
}
