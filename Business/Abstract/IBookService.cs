using Core.Utilities.Results;
using Entities.Dtos.Author;
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

        /// <summary>
        /// Belirtilen kitabın detaylarını getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        IResult GetBookDetails(int id);

        /// <summary>
        /// Yeni bir kitap oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="bookCreateDto">Oluşturulacak kitap bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        IResult Create(BookCreateDTO bookCreateDto);

        /// <summary>
        /// Belirtilen kitabı günceller.
        /// </summary>
        /// <param name="bookUpdateDto">Güncellenecek kitabın verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        IResult Update(BookUpdateDTO bookUpdateDto);


    }
}
