namespace Entities.Dtos.BorrowedBook
{
    public class ReturnedBookListDTO
    {
        public int Id { get; set; }
        public string MemberFullName { get; set; }

        public string MemberTckno { get; set; }

        public string BookName { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
