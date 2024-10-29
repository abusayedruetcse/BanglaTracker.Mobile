using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Core.Entities;
using BanglaTracker.Presentation.Utils;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
//using Xamarin.Essentials;

namespace BanglaTracker.Presentation.Views
{
    public partial class TrainTrackingPage : ContentPage
    {
        private Timer _timer;
        private bool _isTracking = false;
        
        private readonly ITrainPointService _trainPointService;

        public TrainTrackingPage(ITrainPointService trainPointService)
        {
            InitializeComponent();
            _trainPointService = trainPointService;
        }

        private async void OnActivateTrackingButtonClicked(object sender, EventArgs e)
        {
            bool isGranted = await PermissionsHelper.RequestLocationPermissions();
            if (isGranted)
            {
                // Handle tracking
                ProcessActivationTracking();
            }
            else
            {
                // Handle permission denial
                await DisplayAlert("Permissions Denied", "Location permissions are required to track the train.", "OK");
            }
        }

        private void ProcessActivationTracking()
        {
            _isTracking = !_isTracking;

            if (_isTracking)
            {
                ActivateButton.Text = "Deactivate Tracking";
                StatusLabel.Text = "Tracking Activated";
                StartTrackingLocation();
            }
            else
            {
                ActivateButton.Text = "Activate Tracking";
                StatusLabel.Text = "Tracking Deactivated";
                StopTrackingLocation();
            }
        }

        private void StartTrackingLocation()
        {
            // Start the timer to get location every minute
            _timer = new Timer(async _ => await GetLocationAndSendToBackend(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        private void StopTrackingLocation()
        {
            _timer?.Change(Timeout.Infinite, 0);
        }

        private async Task GetLocationAndSendToBackend()
        {
            try
            {
                // Get the current location
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best));
                if (location != null)
                {
                    // Prepare data to send to the backend
                    var locationData = new LocationData
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                        Timestamp = DateTime.UtcNow
                    };

                    // Send location data to the backend
                    await _trainPointService.SendGeolocationDataAsync(locationData);

                    Console.WriteLine($"Tracker XXX: {DateTime.UtcNow}, ({location.Latitude}, {location.Longitude})");
                }                
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                Console.WriteLine($"Error getting location: {ex.Message}");
            }
        }
    }
}
