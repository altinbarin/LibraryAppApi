using Core.Enums;

namespace Core.Entities.Concrete
{
    public class BaseEntity: IEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; } 
        public DateTime ModifiedDate { get; set; }
    }
}
