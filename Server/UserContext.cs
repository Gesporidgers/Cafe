using Microsoft.EntityFrameworkCore;

namespace Server
{
	public class UserContext : DbContext
	{
		public DbSet<User> users { get; set; } = null!;

		public UserContext(DbContextOptions<UserContext> options): base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source = Users.db");
		}
	}
}
