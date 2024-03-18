using Core.Utilities.Results;
using Entities.Dtos.Author;
using Entities.Dtos.Publisher;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        /// <summary>
        /// Tüm yayın evlerini listeler
        /// </summary>
        /// <returns></returns>
        IResult GetAll();


        /// <summary>
        /// Belirtilen yayın evinin detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak yayın evinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        IResult GetById(int id);

        /// <summary>
        /// Yeni bir yayınevi oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="publisherCreateDto">Oluşturulacak yayınevi bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        IResult Create(PublisherCreateDTO publisherCreateDto);


        /// <summary>
        /// Belirtilen yayınevi günceller.
        /// </summary>
        /// <param name="publisherUpdateDto">Güncellenecek yayınevinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        IResult Update(PublisherUpdateDTO publisherUpdateDto);
    }
}
