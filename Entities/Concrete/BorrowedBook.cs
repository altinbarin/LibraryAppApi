using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class BorrowedBook:BaseEntity
    {
        public int MemberId { get; set; }

        public int BookId { get; set; }

        public DateTime BorrowDate { get; set; }=DateTime.Now;
        public DateTime? ReturnDate { get; set; }

    }
}
