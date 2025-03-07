using Client.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Client
{
	public partial class MainPage : ContentPage
	{

		HttpClient httpClient = new HttpClient();
		public MainPage()
		{
			InitializeComponent();
            
        }

		private async void Button_Clicked(object sender, EventArgs e)
		{
			string nm = uname.Text;
			try
			{
				var resp = await httpClient.GetFromJsonAsync<User>("https://localhost:7032/api/Users/" + nm);
				await Navigation.PushAsync(new WaiterPage());
			}
			catch (HttpRequestException ex)
			{
				await DisplayAlert("Ошибка", "Пользователя с таким именем не существует", "ОК");
			}
		}
	}

}
