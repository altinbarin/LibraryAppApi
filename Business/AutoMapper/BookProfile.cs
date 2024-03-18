using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Book;

namespace Business.AutoMapper
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book,BookCreateDTO>();
            CreateMap<Book,BookListDTO>();
            CreateMap<Book,BookUpdateDTO>();
        }
    }
}
