using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Member;

namespace Business.Concrete
{
    public class MemberService : IMemberService
    {
        readonly IMemberRepository _memberRepository;
        readonly IMapper _mapper;
        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public IResult GetAll()
        {
            var genres = _memberRepository.GetAll();
            if (genres.Count() <= 0)
                return new ErrorResult(Messages.MembersNotFound);

            var genreDtos = _mapper.Map<List<MemberListDTO>>(genres);
            return new SuccessDataResult<List<MemberListDTO>>(genreDtos, Messages.MemberListedSuccessfully);
        }
    }

}
