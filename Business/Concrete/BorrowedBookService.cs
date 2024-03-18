using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.BorrowedBook;

namespace Business.Concrete
{
    public class BorrowedBookService : IBorrowedBookService
    {
        readonly IBorrowedBookRepository _borrowedBookRepository;
        readonly IMapper _mapper;
        public BorrowedBookService(IBorrowedBookRepository borrowedBookRepository, IMapper mapper)
        {
            _borrowedBookRepository = borrowedBookRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm ödünç alınan kitapları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetAll()
        {
            var borrowedBooks = _borrowedBookRepository.GetAll(borrowedBooks=>borrowedBooks.Status);
            if(borrowedBooks.Count() <= 0)
                return new ErrorResult(Messages.BorrowedBooksNotFound);

            var borrowedBookDtos = _mapper.Map<List<BorrowedBookListDTO>>(borrowedBooks);

            return new SuccessDataResult<List<BorrowedBookListDTO>>(borrowedBookDtos, Messages.BorrowedBooksListedSuccessfully);
        }


        /// <summary>
        /// Belirtilen ödünç alınan kitapların detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak ödünç alınan kitapların kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetById(int id)
        {
            var borrowedBooks = _borrowedBookRepository.Get(borrowedBook=>borrowedBook.Id == id && borrowedBook.Status);

            if(borrowedBooks == null)
                return new ErrorResult(Messages.BorrowedBookNotFound);

            var borrowedBookDto = _mapper.Map<BorrowedBookDetailDTO>(borrowedBooks);

            return new SuccessDataResult<BorrowedBookDetailDTO>(borrowedBookDto, Messages.BorrowedBookListedSuccessfully);
        }
    }

}
