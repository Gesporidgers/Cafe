using Client.Models;
using Server;

namespace Client;

public partial class WaiterPage : ContentPage
{
	WaiterBrainVM vm = new WaiterBrainVM();
	//public List<FoodItem> mm;
	public WaiterPage()
	{
		//mm = vm.Menu;
		InitializeComponent();
		BindingContext = vm;
	}
}