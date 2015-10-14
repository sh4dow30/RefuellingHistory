using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh4dow.RefuellingHistory.Models
{
    public class RefuellingHistoryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Refuelling> Refuellings { get; set; }
    }
}
