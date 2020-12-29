using Microsoft.EntityFrameworkCore;
using RoleDataModel.Models;
using UnitDataModel.Models;
using URoleDataModel.Models;

namespace UserDataModel.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
        }


        public DbSet<User> users { get; set; }
        public DbSet<Unit> units { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<URole> uRoles { get; set; }

    }

}
