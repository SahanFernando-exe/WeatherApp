using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherData
    {
        [JsonPropertyName("latitude")]
        public float lat { get; set; }

        [JsonPropertyName("longitude")]
        public float lon { get; set; }
        public string city { get; set; }
        public Current current { get; set; }
        public Hourly hourly { get; set; }
    }

    public class Current
    {
        public string time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public float temp { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public float app_temp { get; set; }

        [JsonPropertyName("cloud_cover")]
        public float cloud { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public float humidity { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public float precip { get; set; }

        [JsonPropertyName("wind_gusts_10m")]
        public float wind_gusts { get; set; }
    }

    public class Hourly
    {
        public List<DateTime> time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<float> temp { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public List<float> app_temp { get; set; }

        [JsonPropertyName("cloud_cover")]
        public List<float> cloud { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public List<float> humidity { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public List<float> precip { get; set; }

        [JsonPropertyName("wind_gusts_10m")]
        public float wind_gusts { get; set; }
    }
}
