using BanglaTracker.Core.Entities;
using BanglaTracker.Core.Interfaces;
using System.Net.Http.Json;

namespace BanglaTracker.Infrastructure.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LocationPoint>> GetTrainPointsAsync()
        {
            try
            {
                // Fetch geolocation API URL from configuration
                var baseUrl = "https://192.168.0.100:44382/";
                var weatherEndpoint = "api/WeatherForecast";

                var trainPointsUrl = string.Concat(baseUrl, weatherEndpoint);
                if (string.IsNullOrEmpty(trainPointsUrl))
                {
                    throw new InvalidOperationException("Train points URL is not configured.");
                }

                // Get train points data
                var response = await _httpClient.GetFromJsonAsync<List<LocationPoint>>(trainPointsUrl);
                return response ?? new List<LocationPoint>();
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP Request Error in GetTrainPointsAsync: {httpEx.Message}");
                return new List<LocationPoint>(); // Return empty list on failure
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTrainPointsAsync: {ex.Message}");
                return new List<LocationPoint>();
            }
        }

        public async Task SendGeolocationDataAsync(LocationData locationData)
        {
            try
            {
                // Fetch geolocation API URL from configuration
                var baseUrl = "https://192.168.0.100:44382/";
                var locationDataEndpoint = "api/Location";

                var geolocationUrl = string.Concat(baseUrl, locationDataEndpoint);
                if (string.IsNullOrEmpty(geolocationUrl))
                {
                    throw new InvalidOperationException("Geolocation URL is not configured.");
                }

                // Send location data to the backend
                var response = await _httpClient.PostAsJsonAsync(geolocationUrl, locationData);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP Request Error in SendGeolocationDataAsync: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SendGeolocationDataAsync: {ex.Message}");
            }
        }
    }
}

