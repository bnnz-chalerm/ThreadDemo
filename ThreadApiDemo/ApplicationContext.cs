using Microsoft.EntityFrameworkCore;
using MyWebApi.Users;

namespace ThreadApiDemo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<UserDto> User { get; set; }
    }
}
