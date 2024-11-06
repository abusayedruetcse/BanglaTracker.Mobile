using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Presentation.Utils;

namespace BanglaTracker.Presentation.Views;

public partial class JourneySearchPage : ContentPage
{
    private readonly ITrainPointService _trainPointService;
    private readonly IServiceProvider _serviceProvider;
    private bool _isDataLoaded;

    public JourneySearchPage(
        ITrainPointService trainPointService,
        IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _trainPointService = trainPointService;
        _serviceProvider = serviceProvider;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Check if data has already been loaded
        if (!_isDataLoaded)
        {
            await LoadStationDataAsync();
            await LoadTrainDataAsync();
            _isDataLoaded = true;  // Set the flag to true after data is loaded
        }
    }

    protected override bool OnBackButtonPressed()
    {
        // Do something here 
        return base.OnBackButtonPressed();
    }

    private async Task LoadStationDataAsync()
    {
        // Fetch station data from a service or database
        var stations = await _trainPointService.GetAllStationsAsync();
        
        FromStationPicker.ItemsSource = stations;
        ToStationPicker.ItemsSource = stations;
        CurrentStationPicker.ItemsSource = stations;
    }

    private async Task LoadTrainDataAsync()
    {
        // Fetch train data from a service or database
        var trains = await _trainPointService.GetAllTrainsAsync();
        TrainPicker.ItemsSource = trains;
    }

    private async void OnSearchBtnClicked(object sender, EventArgs e)
    {
        var item = FromStationPicker.SelectedItem;

        // Resolve JourneySearchPage from the DI container
        var detailsPage = _serviceProvider.GetRequiredService<TwoStationsDetailPage>();

        // Navigate to JourneySearchPage
        await Navigation.PushAsync(detailsPage);
    }

    private void OnFromStationChanged(object sender, EventArgs e)
    {
        // Set CurrentStationPicker's selected item to match ToStationPicker by default
        CurrentStationPicker.SelectedItem = FromStationPicker.SelectedItem;
    }
}

