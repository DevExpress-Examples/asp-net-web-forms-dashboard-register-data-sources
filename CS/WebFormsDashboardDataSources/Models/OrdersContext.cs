namespace WebFormsDashboardDataSources {
    using System.Data.Entity;

    public partial class OrdersContext: DbContext {
        public OrdersContext()
            : base("name=OrdersContext") {
        }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 4);
        }
    }
}
