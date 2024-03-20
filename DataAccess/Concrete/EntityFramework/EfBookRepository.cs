using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Book;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookRepository : EfEntityRepositoryBase<Book, LibraryContext>, IBookRepository
    {
        public BookDetailDTO GetBookDetails(int id)
        {
            using (var context = new LibraryContext())
            {
                var result = from book in context.Books
                    join author in context.Authors on book.AuthorId equals author.Id
                    join genre in context.Genres on book.GenreId equals genre.Id
                    join publisher in context.Publishers on book.PublisherId equals publisher.Id
                    where book.Id == id
                    select new BookDetailDTO
                    {
                        Id = book.Id,
                        Name = book.Name,
                        TotalStock = book.TotalStock,
                        InStock = book.InStock,
                        Section = book.Section,
                        GenreName = genre.Name,
                        PublisherName = publisher.Name,
                        AuthorFullName = author.Name + " " + author.Surname,
                        CreatedDate = book.CreatedDate
                    };

                return result.SingleOrDefault();
            }
        }
    }
}
