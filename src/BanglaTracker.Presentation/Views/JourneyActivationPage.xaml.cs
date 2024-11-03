using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Core.Entities;
using BanglaTracker.Presentation.Utils;

namespace BanglaTracker.Presentation.Views;

public partial class JourneyActivationPage : ContentPage
{
    private Timer _timer;
    private bool _isTracking = false;

    private readonly ITrainPointService _trainPointService;
    private readonly IServiceProvider _serviceProvider;

    public JourneyActivationPage(
        ITrainPointService trainPointService,
        IServiceProvider serviceProvider)
    {
        InitializeComponent();
        LoadStationData();
        LoadTrainData();
        
        _trainPointService = trainPointService;
        _serviceProvider = serviceProvider;
    }

    protected override bool OnBackButtonPressed()
    {
        // Do something here 
        return base.OnBackButtonPressed();
    }

    private void LoadStationData()
    {
        // Fetch station data from a service or database
        var stations = new List<string> { "Station A", "Station B", "Station C" };
        FromStationPicker.ItemsSource = stations;
        ToStationPicker.ItemsSource = stations;
        CurrentStationPicker.ItemsSource = stations;
    }

    private void LoadTrainData()
    {
        // Fetch train data from a service or database
        var trains = new List<string> { "Train 1", "Train 2", "Train 3" };
        TrainPicker.ItemsSource = trains;
    }

    private async void OnStartJourneyClicked(object sender, EventArgs e)
    {
        try
        {
            // Disable the button immediately to prevent multiple clicks
            StartJourneyButton.IsEnabled = false;

            var fromStation = FromStationPicker.SelectedItem as string;
            var toStation = ToStationPicker.SelectedItem as string;
            var trainName = TrainPicker.SelectedItem as string;
            var currentStation = CurrentStationPicker.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(fromStation) 
                || string.IsNullOrWhiteSpace(toStation) 
                || string.IsNullOrWhiteSpace(trainName)
                || string.IsNullOrWhiteSpace(currentStation))
            {
                StartJourneyButton.IsEnabled = true;
                
                await DisplayAlert("Error", "Please fill in all fields.", "OK");

                return;
            }

            // Call the API or internal service to start the journey and handle location tracking
            var response = await _trainPointService.StartJourneyAsync(
                fromStation, 
                toStation,                
                trainName,
                currentStation,
                InstallationIdProvider.GetInstallationId());

            if (response.IsSuccess)
            {
                await DisplayAlert("Success", "Journey started successfully!", "OK");
                
                // Disable button after success, and possibly show a success message
                StartJourneyButton.Text = "Journey Started";
                StartJourneyButton.BackgroundColor = Colors.Gray; // Update color to indicate it's inactive

                // Enable the button to activate tracking.
                ActivateTrackingButton.IsEnabled = true;
                ActivateTrackingButton.BackgroundColor = Colors.RoyalBlue;

                StopJourneyButton.IsEnabled = true;
                StopJourneyButton.Text = "Stop Journey";
                StopJourneyButton.BackgroundColor = Colors.RoyalBlue;
            }
            else
            {
                // Enable the button again if response indicates failure
                StartJourneyButton.IsEnabled = true;

                await DisplayAlert("Error", "Failed to start journey.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Log or handle exception
            Console.WriteLine($"Error in StartJourneyAsync: {ex.Message}");

            // Re-enable the button if there's an error
            StartJourneyButton.IsEnabled = true;
            await DisplayAlert("Error", "An error occurred. Please try again.", "OK");
        }
    }

    #region Activate-Deactivate Tracking
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
            ActivateTrackingButton.Text = "Deactivate Tracking";
            StartTrackingLocation();

            StopJourneyButton.IsEnabled = false;
            StopJourneyButton.BackgroundColor = Colors.Gray;
        }
        else
        {
            ActivateTrackingButton.Text = "Activate Tracking";
            StopTrackingLocation();

            StopJourneyButton.IsEnabled = true;
            StopJourneyButton.BackgroundColor = Colors.RoyalBlue;
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
                    InstallationID = InstallationIdProvider.GetInstallationId(),
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    ModifiedDateTime = DateTime.UtcNow
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

    #endregion Activate-Deactivate Tracking

    private void OnStopJourneyClicked(object sender, EventArgs e)
    {
        // Disable the button immediately to prevent multiple clicks
        StopJourneyButton.IsEnabled = false;
        StopJourneyButton.Text = "Journey Stopped";
        StopJourneyButton.BackgroundColor = Colors.Gray;

        // Disable the button to activate tracking.
        ActivateTrackingButton.IsEnabled = false;
        ActivateTrackingButton.BackgroundColor = Colors.Gray;

        // Enable journey button
        StartJourneyButton.IsEnabled = true;
        StartJourneyButton.Text = "Start Journey";
        StartJourneyButton.BackgroundColor = Colors.RoyalBlue;

        // Reset train details
        FromStationPicker.SelectedItem = null;
        ToStationPicker.SelectedItem = null;
        TrainPicker.SelectedItem = null;

    }

    private void OnFromStationChanged(object sender, EventArgs e)
    {
        // Set CurrentStationPicker's selected item to match ToStationPicker by default
        CurrentStationPicker.SelectedItem = FromStationPicker.SelectedItem;
    }
}

