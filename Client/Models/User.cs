using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models
{
	public class User
	{
		public enum userRole
		{
			Waiter,
			Chef
		}
		public long Id { get; set; }
		public string Name { get; set; }
		public userRole Role { get; set; }

		public User(long id, string name, userRole role)
		{
			Id = id;
			Name = name;
			Role = role;
		}
	}
}
