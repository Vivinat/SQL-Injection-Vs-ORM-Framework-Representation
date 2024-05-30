using InjectionClinic.Entities;
using Microsoft.EntityFrameworkCore;

namespace InjectionClinic.Contexts
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }
        public DbSet<userinfo> userinfo { get; set; }

    }
}
