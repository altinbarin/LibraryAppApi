using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Genre;

namespace Business.AutoMapper
{
    public class GenreProfile:Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreCreateDTO>();
            CreateMap<Genre, GenreUpdateDTO>();
            CreateMap<Genre, GenreListDTO>();
        }
    }
}
