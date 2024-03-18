using Core.Utilities.Results;
using Entities.Dtos.Book;

namespace Business.Abstract
{
    public interface IBookService
    {

        /// <summary>
        /// Tüm kitapları listeler
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür</returns>
        IResult GetAll();

        /// <summary>
        /// Belirtilen kitapların detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak kitapın idsi.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        IResult GetById(int id);
    }
}
