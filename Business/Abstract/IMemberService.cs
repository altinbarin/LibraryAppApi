using Core.Utilities.Results;
using Entities.Dtos.Author;
using Entities.Dtos.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMemberService
    {
        /// <summary>
        /// Tüm üyeleri listeler
        /// </summary>
        /// <returns></returns>
        IResult GetAll();

        /// <summary>
        /// Belirtilen üyenin detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak üyenin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        IResult GetById(int id);

        /// <summary>
        /// Yeni bir üye oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="memberCreateDto">Oluşturulacak üye bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        IResult Create(MemberCreateDTO memberCreateDto);


        /// <summary>
        /// Belirtilen üyeyi günceller.
        /// </summary>
        /// <param name="memberUpdateDto">Güncellenecek üyenin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        IResult Update(MemberUpdateDTO memberUpdateDto);
    }
}
