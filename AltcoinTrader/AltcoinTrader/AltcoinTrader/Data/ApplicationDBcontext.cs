using AltcoinTrader.Models;
using Microsoft.EntityFrameworkCore;

namespace AltcoinTrader.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
           : base(options)
        {
        }
        public DbSet<Coin> Coins { get; set; }
    }
    
}
