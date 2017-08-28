using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ZooFeeding.Models;

namespace ZooFeeding.DAL
{
    public class ZooContext : DbContext
    {
        public ZooContext() : base("ZooContext")
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}