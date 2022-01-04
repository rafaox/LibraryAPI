using LibraryApi.Services.Contracts;
using LibraryApi.Services.Repositories;

namespace LibraryApi.Config
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAsyncRepository, AsyncRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}