namespace Entities.Dtos.Book
{
    public class BookListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalStock { get; set; }
        public int InStock { get; set; }
        public string Section { get; set; }


        //public DateTime CreatedDate { get; set; }
        //public string AuthorFullName { get; set; }
        //public string PublisherName { get; set; }
        //public string GenreName{ get; set; }
    }
}
