using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Enums;
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

        

        public IResult GetAll()
        {
            var books =  _bookRepository.GetAll();
            if(books.Count()<=0)
                return new ErrorResult(Messages.BooksNotFound);

            var bookDtos = _mapper.Map<List<BookListDTO>>(books);

            return new SuccessDataResult<List<BookListDTO>>(bookDtos, Messages.BookListedSuccessfully);
            
        }

       

       
    }
}
