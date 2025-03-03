using Microsoft.EntityFrameworkCore;

namespace Server
{
	public class MenuContext :DbContext
	{
		public DbSet<FoodItem> menu { get; set; } = null!;

		public MenuContext(DbContextOptions<MenuContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source = Menu.db");
		}
	}
}
