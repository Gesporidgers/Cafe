namespace Server
{
	public class Order
	{
		public long Id { get; set; }
		public enum status
		{
			Placed,
			Preparing,
			Ready,
			Out,
			Completed
		}
		public int[] Food { get; set; } //может также использовать uint?
		public status Status { get; set; }
		public uint Table { get; set; }
	}
}
