namespace Server
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
		public int[] Food { get; set; }
		// Dictionary<int, int> Food
		public status Status { get; set; }
	}
}
