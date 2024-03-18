using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidationWithAssemblies(this IServiceCollection services)
        {

            services
            .AddFluentValidationAutoValidation(config => config.DisableDataAnnotationsValidation = true) 
            //"config => config.DisableDataAnnotationsValidation = true" yapılmasının sebebi validation mesajları gelirken DATA ANNOTATİON tarafından düşen default mesajları devre dışı bırakmak için yapılmıştır.
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
