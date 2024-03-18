using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Author;

namespace Business.AutoMapper
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorCreateDTO>();
            CreateMap<Author, AuthorListDTO>();
            CreateMap<Author, AuthorUpdateDTO>();
        }
    }
}
