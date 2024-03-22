using Core.Utilities.Results;
using Entities.Dtos.BorrowedBook;

namespace Business.Abstract
{
    public interface IBorrowedBookService
    {
        /// <summary>
        /// Ödünç alınan kitapları yazar isim-soyismi ve kitap ismi ile birlikte listeler
        /// </summary>
        /// <returns>İşlemin başarı durumu ve verileri içeren bir sonuç nesnesi döndürür</returns>
        IResult GetAll();

        /// <summary>
        /// İade edilen kitapları listeler
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür</returns>
        IResult GetAllBooksReturned();


        /// <summary>
        /// Belirtilen ödünç alınan kitapların detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak ödünç alınan kitabın kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        IResult GetById(int id);


        /// <summary>
        /// Ödünç alınan kitap oluşturur.
        /// </summary>
        /// <param name="borrowedBookCreateDto"></param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür</returns>
        IResult Create(BorrowedBookCreateDTO borrowedBookCreateDto);


        /// <summary>
        /// Ödünç alınan kitabın iadesini yapar.
        /// </summary>
        /// <param name="borrowedBookId">ödünç alınan kitabın bilgilerinin kimliği</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür</returns>
        IResult BookReturn(int borrowedBookId);
    }
}
