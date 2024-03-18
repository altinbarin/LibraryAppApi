using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Author;

namespace Business.Concrete
{
    public class AuthorService : IAuthorService
    {
        readonly IAuthorRepository _authorRepository;
        readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public IResult GetAll()
        {
            var books = _authorRepository.GetAll();
            if (books.Count() <= 0)
                return new ErrorResult(Messages.AuthorsNotFound);

            var bookDtos = _mapper.Map<List<AuthorListDTO>>(books);

            return new SuccessDataResult<List<AuthorListDTO>>(bookDtos, Messages.AuthorListedSuccessfully);
        }
    }
}
