using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBorrowedBookService
    {
        /// <summary>
        /// Tüm ödünç alınan kitapları listeler
        /// </summary>
        /// <returns></returns>
        IResult GetAll();


        /// <summary>
        /// Belirtilen ödünç alınan kitapların detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak ödünç alınan kitabın kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        IResult GetById(int id);
    }
}
