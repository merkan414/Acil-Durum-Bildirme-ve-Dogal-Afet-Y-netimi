using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AGAD.Models.Mapping;

namespace AGAD.Models
{
    public partial class agadContext : DbContext
    {
        static agadContext()
        {
            Database.SetInitializer<agadContext>(null);
        }

        public agadContext()
            : base("Name=agadContext")
        {
        }

        public DbSet<AGAD> AGADs { get; set; }
        public DbSet<AGADTYPE> AGADTYPEs { get; set; }
        public DbSet<CITY> CITies { get; set; }
        public DbSet<CONFIRMSTATE> CONFIRMSTATEs { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TOWN> TOWNs { get; set; }
        public DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AGADMap());
            modelBuilder.Configurations.Add(new AGADTYPEMap());
            modelBuilder.Configurations.Add(new CITYMap());
            modelBuilder.Configurations.Add(new CONFIRMSTATEMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TOWNMap());
            modelBuilder.Configurations.Add(new USERMap());
        }
    }
}
