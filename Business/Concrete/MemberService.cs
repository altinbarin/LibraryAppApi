using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Activate(int id)
        {
            try
            {
                var member = _memberRepository.Get(member => member.Id == id && !member.Status);
                if (member == null)
                    return new ErrorResult(Messages.MemberNotFound);

                member.Status = true;
                member.DeletedDate = null;
                member.ModifiedDate = DateTime.Now;
                _memberRepository.Update(member);
                return new SuccessResult(Messages.MemberActivatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.MemberCanNotActivate);
            }
        }

        /// <summary>
        /// Yeni bir üye oluşturma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="memberCreateDto">Oluşturulacak üye bilgilerini taşıyan DTO.</param>
        /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
        public IResult Create(MemberCreateDTO memberCreateDto)
        {
            try
            {
                var hasMember = _memberRepository.Get(member => member.Email == memberCreateDto.Email);
                if (hasMember != null)
                    return new ErrorResult(Messages.MemberAlreadyExists);

                var member = _mapper.Map<Member>(memberCreateDto);
                _memberRepository.Add(member);
                return new SuccessResult(Messages.MemberCreatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.MemberCanNotCreated);
            }
           
        }

        public IResult Delete(int id)
        {
            try
            {
                var member = _memberRepository.Get(member => member.Id == id && member.Status);
                if (member == null)
                    return new ErrorResult(Messages.MemberNotFound);

                member.Status = false;
                member.DeletedDate = DateTime.Now;
                _memberRepository.Update(member);
                return new SuccessResult(Messages.MemberDeletedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.MemberCanNotDeleted);
            }
        }


        /// <summary>
        /// Tüm üyeleri listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetAll()
        {
            var members = _memberRepository.GetAll(members=>members.Status);
            if (members.Count() <= 0)
                return new ErrorResult(Messages.MembersNotFound);

            var memberDtos = _mapper.Map<List<MemberListDTO>>(members);
            return new SuccessDataResult<List<MemberListDTO>>(memberDtos, Messages.MembersListedSuccessfully);
        }

        public IResult GetAllDeleted()
        {
            var members = _memberRepository.GetAll(members => !members.Status);
            if (members.Count() <= 0)
                return new ErrorResult(Messages.MembersNotFound);

            var memberDtos = _mapper.Map<List<MemberListDTO>>(members);
            return new SuccessDataResult<List<MemberListDTO>>(memberDtos, Messages.MembersListedSuccessfully);
        }

        /// <summary>
        /// Belirtilen üyenin detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak üyenin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetById(int id)
        {
            var member = _memberRepository.Get(m => m.Id == id && m.Status);
            if (member == null)
                return new ErrorResult(Messages.MemberNotFound);

            var memberDto = _mapper.Map<MemberDetailDTO>(member);
            return new SuccessDataResult<MemberDetailDTO>(memberDto, Messages.MemberListedSuccessfully);
        }



        /// <summary>
        /// Belirtilen üyeyi günceller.
        /// </summary>
        /// <param name="memberUpdateDto">Güncellenecek üyenin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür.</returns>
        public IResult Update(MemberUpdateDTO memberUpdateDto)
        {
            try
            {
                var member = _memberRepository.Get(member => member.Id == memberUpdateDto.Id && member.Status);
                if (member == null)
                    return new ErrorResult(Messages.MemberNotFound);

                member.ModifiedDate = DateTime.Now;
                member.DeletedDate = null;
                var updatedMember = _mapper.Map<Member>(memberUpdateDto);

                _memberRepository.Update(updatedMember);
                return new SuccessResult(Messages.MemberUpdatedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.MemberCanNotUpdated);
            }
        }
    }

}
