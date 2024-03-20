using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
        /// Yeni bir kitap oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="bookCreateDto">Oluşturulacak kitap bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        public IResult Create(BookCreateDTO bookCreateDto)
        {
            try
            {
                var hasBook = _bookRepository.Get(book => book.Name == bookCreateDto.Name && book.PublisherId == bookCreateDto.PublisherId);
                if (hasBook != null)
                    return new ErrorResult(Messages.BookAlreadyExists);

                var book = _mapper.Map<Book>(bookCreateDto);
                _bookRepository.Add(book);
                return new SuccessResult(Messages.BookCreatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.BookCanNotCreated);
            }
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
        /// Belirtilen kitabın detaylarını getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetBookDetails(int id)
        {
            var book = _bookRepository.GetBookDetails(id);
            if (book == null)
                return new ErrorResult(Messages.BookNotFound);

            return new SuccessDataResult<BookDetailDTO>(book, Messages.BookListedSuccessfully);
        }


        /// <summary>
        /// Belirtilen kitapların detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak kitapların kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetById(int id)
        {
            var book = _bookRepository.Get(books=>books.Id==id && books.Status);
            if(book==null)
                return new ErrorResult(Messages.BookNotFound);

            var bookDto = _mapper.Map<BookDetailDTO>(book);
            return new SuccessDataResult<BookDetailDTO>(bookDto, Messages.BookListedSuccessfully);
        }

        /// <summary>
        /// Belirtilen kitabı günceller.
        /// </summary>
        /// <param name="bookUpdateDto">Güncellenecek kitabın verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        public IResult Update(BookUpdateDTO bookUpdateDto)
        {
            try
            {
                var book = _bookRepository.Get(books => books.Id == bookUpdateDto.Id && books.Status);
                if (book == null)
                    return new ErrorResult(Messages.BookNotFound);

                var updatedBook = _mapper.Map<Book>(bookUpdateDto);
                updatedBook.ModifiedDate = DateTime.Now;

                _bookRepository.Update(updatedBook);

                return new SuccessResult(Messages.BookUpdatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.BookCanNotUpdated);
            }
        }
    }
}
