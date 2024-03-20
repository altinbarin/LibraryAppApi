using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Book;

namespace DataAccess.Abstract
{
    public interface IBookRepository:IEntityRepository<Book>
    {
        BookDetailDTO GetBookDetails(int id);
    }
}
