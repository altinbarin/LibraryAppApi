using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            //Her gelen request için oluşturulacak olan instatnce'ları oluşturur.

            //Servisler arayüzünün bir örneği, her HTTP isteği için bir örnek oluşturulur.
            //Bu servisler, HTTP isteğinin yaşam döngüsü boyunca aynı örnek üzerinde çalışır.

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowedBookService, BorrowedBookService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IPublisherService, PublisherService>();

            return services;
        }
    }
}
