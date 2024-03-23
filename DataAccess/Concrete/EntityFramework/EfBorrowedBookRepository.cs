using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.BorrowedBook;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBorrowedBookRepository : EfEntityRepositoryBase<BorrowedBook, LibraryContext>, IBorrowedBookRepository
    {
        public List<BorrowedBookListDTO> BorrowedBooksWithAuthorAndBookNames()
        {
            using (var context = new LibraryContext())
            {
                var result = from borrowedBook in context.BorrowedBooks
                             join book in context.Books on borrowedBook.BookId equals book.Id where borrowedBook.ReturnDate == null
                             join member in context.Members on borrowedBook.MemberId equals member.Id
                             select new BorrowedBookListDTO
                             {
                                 Id = borrowedBook.Id,
                                 BookName = book.Name,
                                 MemberFullName = member.Name + " " + member.Surname,
                                 MemberEmail = member.Email,
                                 MemberTckno = member.TCKNO,
                                 BorrowDate = borrowedBook.BorrowDate
                             };

                return result.ToList();
            }
        }

        public List<ReturnedBookListDTO> ReturnedBooksWithAuthorAndBookNames()
        {
            using (var context = new LibraryContext())
            {
                var result = from borrowedBook in context.BorrowedBooks
                             join book in context.Books on borrowedBook.BookId equals book.Id
                             where borrowedBook.ReturnDate != null
                             join member in context.Members on borrowedBook.MemberId equals member.Id
                             select new ReturnedBookListDTO
                             {
                                 Id = borrowedBook.Id,
                                 BookName = book.Name,
                                 MemberFullName = member.Name + " " + member.Surname,
                                 MemberTckno= member.TCKNO,
                                 BorrowDate = borrowedBook.BorrowDate,
                                 ReturnDate = borrowedBook.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
