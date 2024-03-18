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

        public IResult GetAll()
        {
            var borrowedBooks = _borrowedBookRepository.GetAll();
            if(borrowedBooks.Count() <= 0)
                return new ErrorResult(Messages.BorrowedBooksNotFound);

            var borrowedBookDtos = _mapper.Map<List<BorrowedBookListDTO>>(borrowedBooks);

            return new SuccessDataResult<List<BorrowedBookListDTO>>(borrowedBookDtos, Messages.BorrowedBooksListedSuccessfully);
        }
    }

}
