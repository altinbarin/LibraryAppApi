using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Genre;

namespace Business.Concrete
{
    public class GenreService:IGenreService
    {
        readonly IGenreRepository _genreRepository;
        readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }


        public IResult GetAll()
        {
            var genres = _genreRepository.GetAll();
            if (genres.Count() <= 0)
                return new ErrorResult(Messages.GenresNotFound);

            var genreDtos = _mapper.Map<List<GenreListDTO>>(genres);

            return new SuccessDataResult<List<GenreListDTO>>(genreDtos, Messages.GenreListedSuccessfully);

        }
    }

}
