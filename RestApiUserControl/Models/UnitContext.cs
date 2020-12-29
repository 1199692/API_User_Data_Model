using Microsoft.EntityFrameworkCore;

namespace RestApiUserControl.Models
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
        }


        public DbSet<User> users { get; set; }
     
    }

    public class UnitContext : DbContext
    {
        public UnitContext(DbContextOptions<UnitContext> options) : base(options)
        {
        }


        public DbSet<Unit> units { get; set; }

    }

}
