using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Publisher;

namespace Business.AutoMapper
{
    public class PublisherProfile:Profile
    {
        public PublisherProfile()
        {
            CreateMap<PublisherCreateDTO, Publisher>();
            CreateMap<PublisherUpdateDTO, Publisher>();
            CreateMap<Publisher, PublisherListDTO>();
            CreateMap<Publisher, PublisherDetailDTO>();
        }
    }
}
