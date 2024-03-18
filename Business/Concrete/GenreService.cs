using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Genre;

namespace Business.Concrete
{
    public class GenreService : IGenreService
    {
        readonly IGenreRepository _genreRepository;
        readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Yeni bir tür oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="genreCreateDto">Oluşturulacak tür bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        public IResult Create(GenreCreateDTO genreCreateDto)
        {
            
            try
            {
                var hasGenre = _genreRepository.Get(genre => genre.Name.ToLower() == genreCreateDto.Name.ToLower());
                if (hasGenre != null)
                    return new ErrorResult(Messages.GenreAlreadyExists);

                var genre = _mapper.Map<Genre>(genreCreateDto);

                _genreRepository.Add(genre);

                return new SuccessResult(Messages.GenreCreatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.GenreCanNotCreated);
            }
           

        }


        /// <summary>
        /// Tüm türleri listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetAll()
        {
            var genres = _genreRepository.GetAll(genre=>genre.Status);
            if (genres.Count() <= 0)
                return new ErrorResult(Messages.GenresNotFound);

            var genreDtos = _mapper.Map<List<GenreListDTO>>(genres);

            return new SuccessDataResult<List<GenreListDTO>>(genreDtos, Messages.GenresListedSuccessfully);

        }

        /// <summary>
        /// Belirtilen türün detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak türün kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetById(int id)
        {
            var genre = _genreRepository.Get(genre => genre.Id == id && genre.Status);
            if(genre == null)
                return new ErrorResult(Messages.GenreNotFound);

            var genreDto = _mapper.Map<GenreDetailDTO>(genre);
            return new SuccessDataResult<GenreDetailDTO>(genreDto, Messages.GenreListedSuccessfully);

        }


        /// <summary>
        /// Belirtilen türü günceller.
        /// </summary>
        /// <param name="genreUpdateDto">Güncellenecek türün verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        public IResult Update(GenreUpdateDTO genreUpdateDto)
        {
            try
            {
                var genre = _genreRepository.Get(genre => genre.Id == genreUpdateDto.Id);
                if (genre == null)
                    return new ErrorResult(Messages.GenreNotFound);

                genre.ModifiedDate = DateTime.Now;
                var updatedGenre = _mapper.Map<Genre>(genreUpdateDto);
                _genreRepository.Update(updatedGenre);

                return new SuccessResult(Messages.GenreUpdatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.GenreCanNotUpdated);
            }
           
        }
    }

}
