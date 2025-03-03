using System.ComponentModel.DataAnnotations.Schema;

namespace Server
{
	public class User
	{
		public enum role
		{
			Waiter,
			Chef
		}
		public long Id { get; set; }
		public string Name { get; set; } = "";
		public role Role { get; set; }
	}
}
