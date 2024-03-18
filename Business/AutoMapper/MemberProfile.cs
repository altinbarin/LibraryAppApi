using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Member;

namespace Business.AutoMapper
{
    public class MemberProfile:Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberUpdateDTO>();
            CreateMap<Member, MemberListDTO>();
            CreateMap<Member, MemberCreateDTO>();
        }
    }
}
