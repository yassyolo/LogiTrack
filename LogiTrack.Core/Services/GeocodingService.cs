using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace LogiTrack.Core.Services
{
    public class GeocodingService
    {
        private readonly HttpClient httpClient;
        private readonly string googleMapsApiKey = "AIzaSyBsBMQei2VoOA_NoDJdMY-MwRNhT3PMnKM";
        private const string apiKey = "AIzaSyBvWvbU5vFfS0qmdqEsA_ijjj2JBrm1FCI";
        private const string distanceMatrixUrl = "https://maps.googleapis.com/maps/api/distancematrix/json";

        public GeocodingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<string> GetTravelTimeAsync(double pickupLat, double pickupLng, double deliveryLat, double deliveryLng)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = $"{distanceMatrixUrl}?origins={pickupLat},{pickupLng}&destinations={deliveryLat},{deliveryLng}&key={apiKey}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(content);

                    var duration = jsonResponse["rows"][0]["elements"][0]["duration"]["text"].ToString();
                    return duration;
                }
                else
                {
                    return "Error retrieving data";
                }
            }
        }

        public async Task<(double Latitude, double Longtitude)?> GetCoordinates(string address)
        {
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={googleMapsApiKey}";

            var response = await httpClient.GetFromJsonAsync<GeocodingResponse>(url);

            if (response?.Results?.Any() == true)
            {
                var location = response.Results.First().Geometry.Location;
                return (location.Latitude, location.Longitude);
            }

            return null;
        }

        public async Task<string?> GetAddress(double latitude, double longitude)
        {
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={googleMapsApiKey}";

            var response = await httpClient.GetFromJsonAsync<GeocodingResponse>(url);

            if (response?.Results?.Any() == true)
            {
                return response.Results.First().FormattedAddress;
            }

            return null;
        }

        private class GeocodingResponse
        {
            [JsonPropertyName("results")]
            public Result[] Results { get; set; } = null!;

            [JsonPropertyName("status")]
            public string Status { get; set; } = null!;
        }

        private class Result
        {
            [JsonPropertyName("address_components")]
            public List<AddressComponent> AddressComponents { get; set; } = null!;

            [JsonPropertyName("formatted_address")]
            public string FormattedAddress { get; set; } = string.Empty;

            [JsonPropertyName("geometry")]
            public Geometry Geometry { get; set; } = null!;

            [JsonPropertyName("place_id")]
            public string PlaceId { get; set; } = string.Empty;

            [JsonPropertyName("types")]
            public List<string> Types { get; set; } = null!;
        }
        public class AddressComponent
        {
            [JsonPropertyName("long_name")]
            public string LongName { get; set; } = string.Empty;

            [JsonPropertyName("short_name")]
            public string ShortName { get; set; } = string.Empty;

            [JsonPropertyName("types")]
            public List<string> Types { get; set; } = null!;
        }
        public class Geometry
        {
            [JsonPropertyName("location")]
            public Location Location { get; set; } = null!;

            [JsonPropertyName("location_type")]
            public string LocationType { get; set; } = string.Empty;

            [JsonPropertyName("viewport")]
            public Viewport Viewport { get; set; } = null!;
        }

        public class Location
        {
            [JsonPropertyName("lat")]
            public double Latitude { get; set; }

            [JsonPropertyName("lng")]
            public double Longitude { get; set; } 
        }

        public class Viewport
        {
            [JsonPropertyName("northeast")]
            public Coordinates Northeast { get; set; } = null!;

            [JsonPropertyName("southwest")]
            public Coordinates Southwest { get; set; } = null!;
        }

        public class Coordinates
        {
            [JsonPropertyName("lat")]
            public double Latitude { get; set; }

            [JsonPropertyName("lng")]
            public double Longitude { get; set; }
        }
    }
}
