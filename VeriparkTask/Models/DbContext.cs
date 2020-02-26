using System.Data.Entity;

namespace VeriparkTask.Models
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("VeriParkTask")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<SpecialDay> SpecialDays { get; set; }
    }
}