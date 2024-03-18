using Core.Utilities.Results;
using Entities.Dtos.Author;
using Entities.Dtos.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenreService
    {
        /// <summary>
        /// Tüm türleri listeler
        /// </summary>
        /// <returns></returns>
        IResult GetAll();

        /// <summary>
        /// Belirtilen türün detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak türün kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        IResult GetById(int id);

        /// <summary>
        /// Yeni bir tür oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="genreCreateDto">Oluşturulacak tür bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        IResult Create(GenreCreateDTO genreCreateDto);

        /// <summary>
        /// Belirtilen türü günceller.
        /// </summary>
        /// <param name="genreUpdateDto">Güncellenecek türün verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        IResult Update(GenreUpdateDTO genreUpdateDto);
    }
}
