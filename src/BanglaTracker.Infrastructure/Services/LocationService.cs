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

        public async Task<List<TrainPoint>> GetTrainPointsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<TrainPoint>>("https://api.example.com/train/points");
            return response ?? new List<TrainPoint>();
        }
    }

}
