using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Publisher;

namespace Business.Concrete
{
    public class PublisherService : IPublisherService
    {
        readonly IPublisherRepository _publisherRepository;
        readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Yeni bir yayınevi oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="publisherCreateDto">Oluşturulacak yayınevi bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        public IResult Create(PublisherCreateDTO publisherCreateDto)
        {
            try
            {
            var hasPublisher = _publisherRepository.Get(publisher => publisher.Name.ToLower() == publisherCreateDto.Name.ToLower());
            if (hasPublisher != null)
                return new ErrorResult(Messages.PublisherAlreadyExists);

                var publisher = _mapper.Map<Publisher>(publisherCreateDto);

                _publisherRepository.Add(publisher);

                return new SuccessResult(Messages.PublisherCreatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.PublisherCanNotCreated);
            }
            

        }

        /// <summary>
        /// Tüm yayın evlerini listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetAll()
        {
            var publishers = _publisherRepository.GetAll(publisher=>publisher.Status);
            if (publishers.Count() <= 0)
                return new ErrorResult(Messages.PublishersNotFound);

            var publisherDtos = _mapper.Map<List<PublisherListDTO>>(publishers);
            return new SuccessDataResult<List<PublisherListDTO>>(publisherDtos, Messages.PublishersListedSuccessfully);
        }

        /// <summary>
        /// Belirtilen yayın evinin detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak yayın evinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetById(int id)
        {
            var publisher = _publisherRepository.Get(publisher => publisher.Id == id && publisher.Status);
            if (publisher == null)
                return new ErrorResult(Messages.PublisherNotFound);

            var publisherDto = _mapper.Map<PublisherDetailDTO>(publisher);
            return new SuccessDataResult<PublisherDetailDTO>(publisherDto, Messages.PublisherListedSuccessfully);
        }


        /// <summary>
        /// Belirtilen yayınevi günceller.
        /// </summary>
        /// <param name="publisherUpdateDto">Güncellenecek yayınevinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        public IResult Update(PublisherUpdateDTO publisherUpdateDto)
        {
            try
            {
                var publisher = _publisherRepository.Get(publisher => publisher.Id == publisherUpdateDto.Id && publisher.Status);
                if (publisher == null)
                    return new ErrorResult(Messages.PublisherNotFound);

                publisher.ModifiedDate = DateTime.Now;

                var updatedPublisher = _mapper.Map<Publisher>(publisherUpdateDto);
                _publisherRepository.Update(updatedPublisher);

                return new SuccessResult(Messages.PublisherUpdatedSuccessfully);

            }
            catch (Exception)
            {
                return new ErrorResult(Messages.PublisherCanNotUpdated);
            }
        }
    }

}
