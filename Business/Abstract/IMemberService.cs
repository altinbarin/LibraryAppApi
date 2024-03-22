using Core.Utilities.Results;
using Entities.Dtos.Member;

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
        /// Silinmiş tüm üyeleri listeler
        /// </summary>
        /// <returns></returns>
        IResult GetAllDeleted();

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


        /// <summary>
        /// Belirtilen üyenin durumunu pasif yapar.
        /// </summary>
        /// <param name="id">Üyenin kimliği</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür</returns>
        IResult Delete(int id);

        /// <summary>
        /// Belirtilen üyenin durumunu aktif yapar.
        /// </summary>
        /// <param name="id">Üyenin kimliği</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür</returns>
        IResult Activate(int id);
    }
}
