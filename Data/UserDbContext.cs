using Microsoft.EntityFrameworkCore;
using Periodic.Models;

namespace Periodic.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions opt): base(opt)
        {
            
        }

        public DbSet<User> Users{get;set;}
    }
}