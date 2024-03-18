using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Book;

namespace Business.Concrete
{
    public class BookService : IBookService
    {
        readonly IBookRepository _bookRepository;
        readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Bütün kitapları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetAll()
        {
            var books =  _bookRepository.GetAll(books=>books.Status);
            if(books.Count()<=0)
                return new ErrorResult(Messages.BooksNotFound);

            var bookDtos = _mapper.Map<List<BookListDTO>>(books);

            return new SuccessDataResult<List<BookListDTO>>(bookDtos, Messages.BooksListedSuccessfully);
            
        }


        /// <summary>
        /// Belirtilen kitapların detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak kitapların kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetById(int id)
        {
            var books = _bookRepository.Get(books=>books.Id==id && books.Status);
            if(books==null)
                return new ErrorResult(Messages.BookNotFound);

            var bookDto = _mapper.Map<BookDetailDTO>(books);
            return new SuccessDataResult<BookDetailDTO>(bookDto, Messages.BookListedSuccessfully);
        }
    }
}
