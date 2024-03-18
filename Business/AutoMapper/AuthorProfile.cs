using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Author;

namespace Business.AutoMapper
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorCreateDTO, Author>();
            CreateMap<AuthorUpdateDTO, Author>();
            CreateMap<Author, AuthorListDTO>();
            CreateMap<Author, AuthorDetailDTO>();
        }
    }
}
