using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Book;

namespace Business.AutoMapper
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();
            CreateMap<Book,BookListDTO>();
            CreateMap<Book,BookDetailDTO>();


        }
    }
}
