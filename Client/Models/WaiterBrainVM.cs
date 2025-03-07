using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    class WaiterBrainVM
    {
        private HttpClient httpClient = new HttpClient();
        private List<FoodItem> menu;

        public List<FoodItem> Menu
        {
            get => menu;
        }

        public WaiterBrainVM()
        {
            var resp = httpClient.GetFromJsonAsync<List<FoodItem>>("https://localhost:7032/api/Menu/");
            menu = resp.Result;
        }
    }
}
