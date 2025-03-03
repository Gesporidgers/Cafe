using Microsoft.EntityFrameworkCore;

namespace Server
{
	public class OrderContext : DbContext
	{
		public DbSet<Order> orders { get; set; } = null!;

		public OrderContext(DbContextOptions<OrderContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source = Orders.db");
		}
	}
}
