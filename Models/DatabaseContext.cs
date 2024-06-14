using Microsoft.EntityFrameworkCore;

namespace SpecCrudPro.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<RegisterModel> RegisterModel { get; set; }
    }
}
