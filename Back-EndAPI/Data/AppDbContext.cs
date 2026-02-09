using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Data  
{
    public class AppDbContext : DbContext
    {
        public DbSet<CharacterEntity> Characters => Set<CharacterEntity>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
