using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMemberRepository:EfEntityRepositoryBase<Member, LibraryContext>, IMemberRepository
    {
       
    }
}
