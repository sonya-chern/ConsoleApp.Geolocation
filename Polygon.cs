using Newtonsoft.Json;

namespace ConsoleApp.Geolocation
{
    /// <summary>
    /// класс для конвертации данных JSON
    /// </summary>
    public class Polygon
    {
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        
        [JsonProperty("licence")]
        public string Licence { get; set; }

        [JsonProperty("osm_type")]
        public string OsmType { get; set; }

        [JsonProperty("osm_id")]
        public string OsmId { get; set; }

        [JsonProperty("boundingbox")]
        public string[] Boundingbox { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("importance")]
        public string Importance { get; set; }

        [JsonProperty("geojson")]
        public GeoJson geojson { get; set; }
    }

    /// <summary>
    /// класс помещен сюда для удобства работы с ним
    /// </summary>
    public class GeoJson
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public object[] Coordinates { get; set; }
    }
}
