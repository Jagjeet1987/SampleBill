using Microsoft.EntityFrameworkCore;

namespace SampleBill.Entity
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    //optionsBuilder.UseSQLite(@"DataSource=mydatabase.db;");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //modelBuilder.Entity<OrderDetail>()
        //    //  .HasKey(p => new { p.OrderID, p.ProductID });
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            //modelBuilder.Entity<Tabs>().ToTable("Tabs");
            //modelBuilder.Entity<RoleTab>().ToTable("RoleTab");

        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        //public DbSet<Tabs> Tabs { get; set; }
        //public DbSet<RoleTab> RoleTab { get; set; }

    }
}
