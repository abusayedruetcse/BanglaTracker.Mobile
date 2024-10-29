using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Core.Entities;
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
            var response = await _httpClient.GetFromJsonAsync<List<LocationPoint>>("https://api.example.com/train/points");
            return response ?? new List<LocationPoint>();
        }

        public async Task SendGeolocationDataAsync(LocationData locationData)
        {
            //Send location data to the backend
            var response = await _httpClient.PostAsJsonAsync("your-backend-endpoint", locationData);
            response.EnsureSuccessStatusCode(); // Check if the response is successful

        }
    }

}
