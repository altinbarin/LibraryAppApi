using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        //General Messages
        public const string ThisFieldIsRequired = "Bu alan zorunludur";
        public const string MaximumLengthIs100 = "Maksimum uzunluk 100 karakter olmalıdır";
        public const string MaximumLengthIs200 = "Maksimum uzunluk 200 karakter olmalıdır";
        public const string MinimumLengthIs1 = "Minimum uzunluk 1 karakter olmalıdır";
        public const string LengthIs11 = "Telefon numarası başında '0' ile birlikte 11 karakter uzunluğunda olmalıdır";
        public const string InvalidEmail = "Uygun bir email adresi giriniz";
        public const string NumberOnly = "Telefon numarası yalnızca sayılardan oluşmalıdır";

        //Book Messages
        public const string BooksListedSuccessfully = "Kitaplar başarıyla listelendi";
        public const string BooksNotFound = "Listelenecek kitap bulunamadı";
        public const string BookListedSuccessfully = "Kitap başarıyla listelendi";
        public const string BookNotFound = "Bu kimliğe sahip kitap bulunamadı";
        public const string BookCanNotCreated = "Kitap oluşturulamadı";
        public const string BookAlreadyExists = "Bu yayınevine sahip kitap zaten var";
        public const string BookCreatedSuccessfully = "Kitap başarıyla oluşturuldu";
        public const string BookCanNotUpdated = "Kitap güncellenemedi";
        public const string BookUpdatedSuccessfully = "Kitap başarıyla güncellendi";

        //Author Messages
        public const string AuthorsNotFound = "Listelenecek yazar bulunamadı";
        public const string AuthorsListedSuccessfully = "Yazarlar başarıyla listelendi";
        public const string AuthorNotFound = "Bu kimliğe sahip yazar bulunamadı";
        public const string AuthorListedSuccessfully = "Yazar başarıyla listelendi";
        public const string AuthorAlreadyExists = "Yazar zaten kayıtlı";
        public const string AuthorCreatedSuccessfully = "Yazar başarıyla kaydedildi";
        public const string AuthorCanNotCreated = "Yazar oluşturulamadı";
        public const string AuthorCanNotUpdated = "Yazar güncellenemedi";
        public const string AuthorUpdatedSuccessfully = "Yazar başarıyla güncellendi";

        //Author Validation Messages



        //BorrowedBook Messages
        public const string BorrowedBooksNotFound = "Listelenecek ödünç kitap bulunamadı";
        public const string BorrowedBooksListedSuccessfully = "Ödünç alınan kitaplar başarıyla listelendi";
        public const string BorrowedBookListedSuccessfully = "Ödünç alınan kitap başarıyla listelendi";
        public const string BorrowedBookNotFound = "Belirtilen kimlikte ödünç alınan kitap bulunamadı";

        //Genre Messages
        public const string GenresNotFound = "Listelenecek tür bulunamadı";
        public const string GenresListedSuccessfully = "Türler başarıyla listelendi";
        public const string GenreNotFound = "Bu kimliğe sahip tür bulunamadı";
        public const string GenreListedSuccessfully = "Tür başarıyla listelendi";
        public const string GenreAlreadyExists = "Tür zaten kayıtlı";
        public const string GenreCanNotCreated = "Tür oluşturulamadı";
        public const string GenreCanNotUpdated = "Tür güncellenemedi";
        public const string GenreCreatedSuccessfully = "Tür başarıyla oluşturuldu";
        public const string GenreUpdatedSuccessfully = "Tür başarıyla güncellendi";

        //Member Messages
        public const string MembersNotFound = "Listelenecek üye bulunamadı";
        public const string MembersListedSuccessfully = "Üyeler başarıyla listelendi";
        public const string MemberListedSuccessfully = "Üye başarıyla listelendi";
        public const string MemberNotFound = "Bu kimliğe sahip üye bulunamadı";
        public const string MemberAlreadyExists = "Üye zaten kayıtlı";
        public const string MemberCreatedSuccessfully = "Üye başarıyla oluşturuldu";
        public const string MemberUpdatedSuccessfully = "Üye başarıyla güncellendi";
        public const string MemberCanNotCreated = "Üye oluşturulamadı";
        public const string MemberCanNotUpdated = "Üye güncellenemedi";

        //Publisher Messages
        public const string PublishersNotFound = "Listelenecek yayınevi bulunamadı";
        public const string PublishersListedSuccessfully = "Yayınevleri başarıyla listelendi";
        public const string PublisherNotFound = "Bu kimliğe sahip yayınevi bulunamadı";
        public const string PublisherListedSuccessfully = "Yayınevi başarıyla listelendi";
        public const string PublisherAlreadyExists = "Yayınevi zaten kayıtlı";
        public const string PublisherCanNotCreated = "Yayınevi oluşturulamadı";
        public const string PublisherCanNotUpdated = "Yayınevi güncellenemedi";
        public const string PublisherCreatedSuccessfully = "Yayınevi başarıyla oluşturuldu";
        public const string PublisherUpdatedSuccessfully = "Yayınevi başarıyla güncellendi";


        

    }
}
