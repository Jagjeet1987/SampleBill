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
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

            });
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");               

            });
            modelBuilder.Entity<JVoucher>(entity =>
            {
                entity.ToTable("JVoucher");

            });
            modelBuilder.Entity<Transaction>().ToTable("Transaction");

        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<JVoucher> JVoucher { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        //public DbSet<Tabs> Tabs { get; set; }
        //public DbSet<RoleTab> RoleTab { get; set; }

    }
}
