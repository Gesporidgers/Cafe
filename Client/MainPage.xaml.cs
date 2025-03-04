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
			var resp = await httpClient.GetStringAsync("https://localhost:7032/api/Users");
			
			var users = JsonSerializer.Deserialize<User[]>(resp, new JsonSerializerOptions(JsonSerializerDefaults.Web));

			if (users.FirstOrDefault(e => e.Name == uname.Text) != null)//переделать на сторону сервера, чтобы возвращалась булева
			{
				await Navigation.PushAsync(new WaiterPage());
			}
			else
			{
				await DisplayAlert("Ошибка", "Пользователя с таким именем не существует", "ОК");
			}
		}
	}

}
