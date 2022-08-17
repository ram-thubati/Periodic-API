using Microsoft.EntityFrameworkCore;
using Periodic.Models;

namespace Periodic.Data
{
    public class SQLPeriodicDbContext : DbContext
    {
        public SQLPeriodicDbContext(DbContextOptions opt) : base(opt)
        {
            
        }

        public DbSet<Account> Accounts {get; set;}

        public DbSet<Transaction> Transactions{get; set;}

        public DbSet<Scheduled> ScheduledTransactions{get; set;}
    }
}