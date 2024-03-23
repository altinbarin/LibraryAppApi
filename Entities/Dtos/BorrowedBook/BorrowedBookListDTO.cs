namespace Entities.Dtos.BorrowedBook
{
    public class BorrowedBookListDTO
    {
        public int Id { get; set; }
        public string MemberFullName { get; set; }

        public string MemberTckno { get; set; }
        public string BookName { get; set; }
        public string MemberEmail { get; set; }
        public DateTime BorrowDate { get; set; }

        //public DateTime? ReturnDate { get; set; }

    }
}
