using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.BorrowedBook;

namespace Business.AutoMapper
{
    public class BorrowedBookProfile:Profile
    {
        public BorrowedBookProfile()
        {
            CreateMap<BorrowedBookCreateDTO, BorrowedBook>();
            CreateMap<BorrowedBookUpdateDTO, BorrowedBook>();
            CreateMap<BorrowedBook, BorrowedBookListDTO>();
            CreateMap<BorrowedBook, BorrowedBookDetailDTO>();
        }
    }
}
