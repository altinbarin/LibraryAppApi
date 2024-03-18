using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        public IResult GetAll()
        {
            var publishers = _publisherRepository.GetAll();
            if (publishers.Count() <= 0)
                return new ErrorResult(Messages.PublishersNotFound);

            var publisherDtos = _mapper.Map<List<PublisherListDTO>>(publishers);
            return new SuccessDataResult<List<PublisherListDTO>>(publisherDtos, Messages.PublisherListedSuccessfully);
        }
    }

}
