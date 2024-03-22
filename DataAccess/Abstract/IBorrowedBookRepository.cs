using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.BorrowedBook;

namespace DataAccess.Abstract
{
    public interface IBorrowedBookRepository:IEntityRepository<BorrowedBook>
    {

        List<BorrowedBookListDTO> BorrowedBooksWithAuthorAndBookNames();

        List<ReturnedBookListDTO> ReturnedBooksWithAuthorAndBookNames();
    }
}
