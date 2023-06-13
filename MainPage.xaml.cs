
using llamadaApi_ER.Model;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace llamadaApi_ER
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEnviarClicked_ER(object sender, EventArgs e)
        {
            string latitud = LatitudEntry_ER.Text;
            string longitud = LongitudEntry_ER.Text;

            using (var client = new HttpClient())
            {
                var url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=b60bb50ef63e7346670bc46589480bee";

                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    var weatherData = JsonConvert.DeserializeObject<Clima>(content);
                    EstadoClima_ER.Text = weatherData.weather[0].description;
                    Pais_ER.Text = weatherData.sys.country;
                    Ciudad_ER.Text = weatherData.name;
                }
            }
        }

    }
}
