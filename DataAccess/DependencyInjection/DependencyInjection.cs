using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEfCoreServices (this IServiceCollection services, IConfiguration configuration)
        {

            //Servisler arayüzünün bir örneği, her HTTP isteği için bir örnek oluşturulur.

            //Bu servisler, HTTP isteğinin yaşam döngüsü boyunca aynı örnek üzerinde çalışır.

            services.AddScoped<IAuthorRepository, EfAuthorRepository>();
            services.AddScoped<IBookRepository, EfBookRepository>();
            services.AddScoped<IBorrowedBookRepository, EfBorrowedBookRepository>();
            services.AddScoped<IGenreRepository, EfGenreRepository>();
            services.AddScoped<IMemberRepository, EfMemberRepository>();
            services.AddScoped<IPublisherRepository, EfPublisherRepository>();


            return services;
        }
    }
}
