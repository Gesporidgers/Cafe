using Client.Utility;

namespace Client.Models
{
	public class FoodItem : BindHelper
	{
		public long id { get; set; }
		public string? Name { get; set; }
		public uint Price { get; set; }

		private uint quantity = 0;

		public uint Quantity
		{
			get => quantity;
			set {  quantity = value; OnPropertyChanged(nameof(Quantity)); }
		}
	}
}
