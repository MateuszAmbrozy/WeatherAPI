using Deserialize_classes;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using DataAccess;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client;
        private const string OWM_Endpoint = "https://api.openweathermap.org/data/2.5/forecast";
        private const string api_key = "06bbad920c03def286244b8718a8330a";
        private WeatherDataRepository myData;
        public int hours = 0;
        Root weatherData;
        public Form1()
        {
            InitializeComponent();

            client = new HttpClient();

            for (int i = 3; i < 24; i = i + 3)
            {
                hours_list.Items.Add(i);
            }
            lon_box.Text = "17.169531";
            lat_box.Text = "51.161729";

            myData = new WeatherDataRepository();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            double latitude, longitude;

            // SprawdŸ, czy lat_box zawiera liczbê i czy jest w odpowiednim zakresie
            if (!double.TryParse(lat_box.Text, out latitude) || latitude < -90 || latitude > 90)
            {
                MessageBox.Show("Wprowadzona szerokoœæ geograficzna jest nieprawid³owa. Szerokoœæ geograficzna powinna byæ liczb¹ z zakresu -90 do 90.");
                return;
            }

            // SprawdŸ, czy lon_box zawiera liczbê i czy jest w odpowiednim zakresie
            if (!double.TryParse(lon_box.Text, out longitude) || longitude < -180 || longitude > 180)
            {
                MessageBox.Show("Wprowadzona d³ugoœæ geograficzna jest nieprawid³owa. D³ugoœæ geograficzna powinna byæ liczb¹ z zakresu -180 do 180.");
                return;
            }
            string call = $"{OWM_Endpoint}?lat={lat_box.Text}&lon={lon_box.Text}&appid={api_key}&cnt={hours_list.Text}";

            string response = await client.GetStringAsync(call);
            weatherData = JsonConvert.DeserializeObject<Root>(response);

            var existingCity = myData.City.FirstOrDefault(c => c.name == weatherData.city.name);
            if (existingCity == null)
            {
                // Dodaj nowe miasto wraz z pe³nymi danymi
                myData.City.Add(weatherData.city);
                foreach (var list in weatherData.list)
                {
                    list.Root = weatherData;
                    list.RootId = weatherData.my_id;
                    myData.List.Add(list);
                }
                myData.weatherDatas.Add(weatherData);
            }
            else
            {
                var existingForecast = myData.List.Where(l => l.Root.city.name == existingCity.name).ToList();

                var newForecasts = weatherData.list.Where(newList => !existingForecast.Any(existingList => existingList.dt_txt == newList.dt_txt)).ToList();
                var weatherDataRoot = myData.weatherDatas.FirstOrDefault(w => w.city.name == weatherData.city.name);
                if (newForecasts.Count > 0)
                {
                    // Dodaj tylko nowe dane prognozy
                    foreach (var newForecast in newForecasts)
                    {
                        newForecast.Root = weatherDataRoot;
                        myData.List.Add(newForecast);
                    }
                }
            }
            bool changesDetected = myData.ChangeTracker.HasChanges();
            myData.SaveChanges();

            if (changesDetected)
                MessageBox.Show($"Liczba dodanych rekordów: {myData.weatherDatas.Count()}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var savedWeatherData = myData.weatherDatas.ToList();
            myData.LoadFullWeatherData(savedWeatherData);

            treeView1.Nodes.Clear();

            foreach (var root in savedWeatherData)
            {
                var cityNode = new TreeNode(root.city.name);
                var temperatureSum = 0.0;
                var temperatureCount = 0;

                foreach (var list in root.list)
                {
                    var listNode = new TreeNode($"Date: {list.dt_txt}, Temp: {Math.Round(list.main.temp - 273, 2)}°C");

                    listNode.Nodes.Add($"Weather: {list.weather.First().main}, {list.weather.First().description}");
                    listNode.Nodes.Add($"Clouds: {list.clouds.all}%");
                    listNode.Nodes.Add($"Wind: {list.wind.speed} m/s, {list.wind.deg} deg");
                    listNode.Nodes.Add($"Visibility: {list.visibility} m");
                    listNode.Nodes.Add($"Pop: {list.pop}");
                    listNode.Nodes.Add($"Sys: {list.sys.pod}");

                    temperatureSum += list.main.temp - 273;
                    temperatureCount++;

                    cityNode.Nodes.Add(listNode);
                }

                var averageTemperature = temperatureSum / temperatureCount;
                cityNode.Text += $" (Avg Temp: {averageTemperature:F2}°C)";

                treeView1.Nodes.Add(cityNode);
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                // SprawdŸ, czy zaznaczony wêze³ jest miastem lub prognoz¹ pogody
                if (treeView1.SelectedNode.Level == 0)
                {
                    int indeksSpacji = treeView1.SelectedNode.Text.IndexOf('(');
                    string selectedCity = treeView1.SelectedNode.Text.Substring(0, indeksSpacji - 1);

                    var weatherDataToRemove = myData.weatherDatas.FirstOrDefault(w => w.city.name == selectedCity);

                    if (weatherDataToRemove != null)
                    {
                        // Usuñ dane pogodowe zwi¹zane z miastem
                        myData.weatherDatas.Remove(weatherDataToRemove);

                        // Usuñ miasto
                        myData.City.Remove(weatherDataToRemove.city);

                        // Usuñ prognozy pogody zwi¹zane z miastem
                        var forecastsToRemove = myData.List.Where(l => l.Root.city.name == selectedCity).ToList();
                        foreach (var forecast in forecastsToRemove)
                        {
                            myData.List.Remove(forecast);
                        }

                        // Zapisz zmiany w bazie danych
                        myData.SaveChanges();

                        // Usuñ zaznaczony wêze³ z treeView1
                        treeView1.Nodes.Remove(treeView1.SelectedNode);

                        MessageBox.Show($"Usuniêto dane pogodowe dla miasta {selectedCity}.");
                    }
                }
                else if (treeView1.SelectedNode.Level == 1)
                {
                    // Pobierz nazwê prognozy pogody z zaznaczonego wêz³a
                    string tekst = treeView1.SelectedNode.Text;
                    string forecastDate = tekst.Substring(5, 20).Trim();

                    int indeksSpacji = treeView1.SelectedNode.Parent.Text.IndexOf('(');
                    string selectedCity = treeView1.SelectedNode.Parent.Text.Substring(0, indeksSpacji - 1);


                    var forecastToRemove = myData.List.FirstOrDefault(l => l.Root.city.name ==  selectedCity && l.dt_txt == forecastDate);
                    if (forecastToRemove != null)
                    {
     
                        myData.List.Remove(forecastToRemove);


                        myData.SaveChanges();


                        treeView1.Nodes.Remove(treeView1.SelectedNode);

                        MessageBox.Show($"Usuniêto prognozê pogody z dnia {forecastDate}.");
                    }
                }
                else
                {
                    MessageBox.Show("Nie mo¿na usun¹æ zaznaczonego wêz³a.");
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono ¿adnego wêz³a.");
            }
        }

    }

}
    

