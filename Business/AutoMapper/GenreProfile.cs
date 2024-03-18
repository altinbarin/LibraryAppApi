using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Genre;

namespace Business.AutoMapper
{
    public class GenreProfile:Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreCreateDTO, Genre>();
            CreateMap<GenreUpdateDTO, Genre>();
            CreateMap<Genre, GenreListDTO>();
            CreateMap<Genre, GenreDetailDTO>();
        }
    }
}
