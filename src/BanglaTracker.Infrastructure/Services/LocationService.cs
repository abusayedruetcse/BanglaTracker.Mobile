using BanglaTracker.Core.DTOs;
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

        public async Task UpdateLastActiveTimeAsync(UserLastActiveDto requestDto)
        {
            try
            {
                // Fetch API URL from configuration
                var baseUrl = "https://192.168.0.100:44382/";
                var apiEndpoint = "api/User/UpdateLastActiveTime";

                var apiUrl = string.Concat(baseUrl, apiEndpoint);
                if (string.IsNullOrEmpty(apiUrl))
                {
                    throw new InvalidOperationException("URL is not configured.");
                }

                // Send this to the backend
                var response = await _httpClient.PostAsJsonAsync(apiUrl, requestDto);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP Request Error in UpdateLastActiveTimeAsync: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateLastActiveTimeAsync: {ex.Message}");
            }
        }

        public async Task<JourneyResponseDto> StartJourneyAsync(LocationData locationData)
        {
            JourneyResponseDto journeyResponse = new JourneyResponseDto();

            try
            {
                // Fetch geolocation API URL and endpoint from configuration
                var baseUrl = "https://192.168.0.100:44382";
                var apiEndpoint = "/api/TrainJourney/{0}/start";

                // Format the endpoint with the journeyId placeholder
                var journeyId = 123; // TODO: Dynamically set the journey ID.
                var apiUrl = $"{baseUrl.TrimEnd('/')}{string.Format(apiEndpoint, journeyId)}";

                if (string.IsNullOrWhiteSpace(apiUrl))
                {
                    throw new InvalidOperationException("Train journey start URL is not configured correctly.");
                }

                // Send location data to the backend
                var response = await _httpClient.PostAsJsonAsync(apiUrl, 1);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content to JourneyResponseDto
                    journeyResponse = await response.Content.ReadFromJsonAsync<JourneyResponseDto>();
                }
                else
                {
                    Console.WriteLine($"Failed to start journey. Status Code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP Request Error in StartJourneyAsync: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in StartJourneyAsync: {ex.Message}");
            }

            return journeyResponse;
        }

    }
}

