using Core.Utilities.Results;
using Entities.Dtos.Book;

namespace Business.Abstract
{
    public interface IBookService
    {

        /// <summary>
        /// Tüm kitapları listeler
        /// </summary>
        /// <returns></returns>
        IResult GetAll();
    }
}
