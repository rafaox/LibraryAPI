using LibraryApi.DataAccessLayer.LibraryApiDbContext;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Config
{
    public static class SqlServerExtensions
    {
        public static void ConfigureSQLServer(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddDbContext<LibraryApiDbContext>((options) => {

                if (env.IsDevelopment())
                {
                    options.LogTo(value => Console.WriteLine(value));
                    options.EnableSensitiveDataLogging();
                }

                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection"),
                    builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                );
            });
        }
    }
}