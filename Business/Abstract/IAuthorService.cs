using Core.Utilities.Results;
using Entities.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        /// <summary>
        /// Tüm yazarları listeler
        /// </summary>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç ve nesneleri döndürür.</returns>
        IResult GetAll();

        /// <summary>
        /// Belirtilen yazarların detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak yazarın idsi.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç ve nesneyi döndürür.</returns>
        IResult GetById(int id);

        /// <summary>
        /// Yeni bir yazar oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="authorCreateDto">Oluşturulacak yazar bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        IResult Create(AuthorCreateDTO authorCreateDto);

        /// <summary>
        /// Belirtilen yazarı günceller.
        /// </summary>
        /// <param name="authorUpdateDto">Güncellenecek yazarın verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        IResult Update(AuthorUpdateDTO authorUpdateDto);
    }
}
