using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Publisher;

namespace Business.AutoMapper
{
    public class PublisherProfile:Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherCreateDTO>();
            CreateMap<Publisher, PublisherListDTO>();
            CreateMap<Publisher, PublisherUpdateDTO>();
        }
    }
}
