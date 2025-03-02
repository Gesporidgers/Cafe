namespace Server
{
	public class Order
	{
		public long id { get; set; }
		public enum Status
		{
			Placed,
			Preparing,
			Out,
			Completed
		}
		public List<int> food { get; set; }
	}
}
