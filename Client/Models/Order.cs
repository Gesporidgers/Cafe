using Java.Util.Functions;

namespace Client.Models
{
	public class Order
	{
		public long Id { get; set; }
		public enum status
		{
			Placed,
			Preparing,
			Out,
			Completed
		}
		public Dictionary<long, uint> Food { get; set; }
		public status Status { get; set; }

		public static explicit operator Order(List<FoodItem> items)
		{
			var dict = new Dictionary<long, uint>();
			foreach (var item in items)
			{
				dict.Add(item.id, item.Quantity);
			}
			return new Order { Id = 0, Food = dict, Status=status.Placed };
		}
	}
}
