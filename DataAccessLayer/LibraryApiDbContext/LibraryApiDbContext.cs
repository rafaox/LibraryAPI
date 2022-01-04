using Microsoft.EntityFrameworkCore;

namespace LibraryApi.DataAccessLayer.LibraryApiDbContext
{
    public class LibraryApiDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public LibraryApiDbContext(DbContextOptions<LibraryApiDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof (LibraryApiDbContext).Assembly);
        }
    }
}