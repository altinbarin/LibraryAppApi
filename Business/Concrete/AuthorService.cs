using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        /// <summary>
        /// Yeni bir yazar oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="authorCreateDto">Oluşturulacak yazar bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        public IResult Create(AuthorCreateDTO authorCreateDto)
        {
            try
            {
                var hasAuthor = _authorRepository.Get(author => author.Name.ToLower() == authorCreateDto.Name.ToLower() && author.Surname.ToLower() == authorCreateDto.Surname.ToLower());
                if (hasAuthor != null)
                    return new ErrorResult(Messages.AuthorAlreadyExists);


                var author = _mapper.Map<Author>(authorCreateDto);

                _authorRepository.Add(author);

                return new SuccessResult(Messages.AuthorCreatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.AuthorCanNotCreated);
            }

        }

        /// <summary>
        /// Tüm yazarları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç döndürür.</returns>
        public IResult GetAll()
        {
            var authors = _authorRepository.GetAll(authors => authors.Status);
            if (authors.Count() <= 0)
                return new ErrorResult(Messages.AuthorsNotFound);

            var authorDtos = _mapper.Map<List<AuthorListDTO>>(authors);

            return new SuccessDataResult<List<AuthorListDTO>>(authorDtos, Messages.AuthorsListedSuccessfully);
        }



        /// <summary>
        /// Belirtilen yazarın detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak yazarın idsi.</param>
        /// <returns>İşlemin başarı durumunu ve veriyi içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetById(int id)
        {
            var author = _authorRepository.Get(author => author.Id == id && author.Status);
            if (author == null)
                return new ErrorResult(Messages.AuthorNotFound);

            var authorDto = _mapper.Map<AuthorDetailDTO>(author);

            return new SuccessDataResult<AuthorDetailDTO>(authorDto, Messages.AuthorListedSuccessfully);

        }


        /// <summary>
        /// Belirtilen yazarı günceller.
        /// </summary>
        /// <param name="authorUpdateDto">Güncellenecek yazarın verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        public IResult Update(AuthorUpdateDTO authorUpdateDto)
        {
            try
            {
                var author = _authorRepository.Get(author => author.Id == authorUpdateDto.Id && author.Status);
                if (author == null)
                    return new ErrorResult(Messages.AuthorNotFound);

                author.ModifiedDate = DateTime.Now;
                var updatedAuthor = _mapper.Map<Author>(authorUpdateDto);
                _authorRepository.Update(updatedAuthor);

                return new SuccessResult(Messages.AuthorUpdatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.AuthorCanNotUpdated);
            }

        }
    }
}
