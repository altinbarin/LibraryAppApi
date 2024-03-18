using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Member;

namespace Business.AutoMapper
{
    public class MemberProfile:Profile
    {
        public MemberProfile()
        {
            CreateMap<MemberCreateDTO, Member>();
            CreateMap<MemberUpdateDTO, Member>();
            CreateMap<Member, MemberListDTO>();
            CreateMap<Member, MemberDetailDTO>();
        }
    }
}
