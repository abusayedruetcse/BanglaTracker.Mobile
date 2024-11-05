using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Presentation.Utils;

namespace BanglaTracker.Presentation.Views;

public partial class JourneySearchPage : ContentPage
{
    private Timer _timer;
    private bool _isTracking = false;

    private readonly ITrainPointService _trainPointService;
    private readonly IServiceProvider _serviceProvider;

    public JourneySearchPage(
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

    private async void OnSearchBtnClicked(object sender, EventArgs e)
    {
        // Resolve JourneySearchPage from the DI container
        var detailsPage = _serviceProvider.GetRequiredService<TwoStationDetailPage>();

        // Navigate to JourneySearchPage
        await Navigation.PushAsync(detailsPage);
    }

    private void OnFromStationChanged(object sender, EventArgs e)
    {
        // Set CurrentStationPicker's selected item to match ToStationPicker by default
        CurrentStationPicker.SelectedItem = FromStationPicker.SelectedItem;
    }
}

