﻿using AnyWhereWeather.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Reflection.Emit;

namespace AnyWhereWeather
{
    public class APIClient
    {


        public Weather GetTheWeather(string zip)
        {
            string key = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?zip={zip}&units=imperial&appid={APIKey}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var json = (JObject.Parse(response.Content));
            var weather = new Weather();
            weather.Temp = (double)json["main"]["temp"];
            weather.FeelsLike = (double)json["main"]["feels_like"];
            weather.MinTemp = (double)json["main"]["temp_min"];
            weather.MaxTemp = (double)json["main"]["temp_max"];
            weather.Humidity = (double)json["main"]["humidity"];
            weather.CityName = (string)json["name"];
            weather.Description = (string)json["weather"][0]["description"];

            return weather;

        }
    }
}


