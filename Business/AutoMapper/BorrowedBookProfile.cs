using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.BorrowedBook;

namespace Business.AutoMapper
{
    public class BorrowedBookProfile:Profile
    {
        public BorrowedBookProfile()
        {
            CreateMap<BorrowedBook, BorrowedBookCreateDTO>();
            CreateMap<BorrowedBook, BorrowedBookListDTO>();
            CreateMap<BorrowedBook, BorrowedBookUpdateDTO>();
        }
    }
}
