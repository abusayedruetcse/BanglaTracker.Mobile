using System.Collections.ObjectModel;
using System.Windows.Input;
using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Core.Entities;
using BanglaTracker.Presentation.Interfaces;
using BanglaTracker.Presentation.Services;
using BanglaTracker.Presentation.Views;

namespace BanglaTracker.Presentation.ViewModels
{
    public class JourneySearchViewModel : BaseViewModel
    {
        private readonly ITrainPointService _trainPointService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Station> Stations { get; } = new();
        public ObservableCollection<Train> Trains { get; } = new();

        private Station _selectedFromStation;
        public Station SelectedFromStation
        {
            get => _selectedFromStation;
            set
            {
                SetProperty(ref _selectedFromStation, value);
                SelectedCurrentStation = value; // Update CurrentStation by default
            }
        }

        private Station _selectedToStation;
        public Station SelectedToStation
        {
            get => _selectedToStation;
            set => SetProperty(ref _selectedToStation, value);
        }

        private Station _selectedCurrentStation;
        public Station SelectedCurrentStation
        {
            get => _selectedCurrentStation;
            set => SetProperty(ref _selectedCurrentStation, value);
        }

        private Train _selectedTrain;
        public Train SelectedTrain
        {
            get => _selectedTrain;
            set => SetProperty(ref _selectedTrain, value);
        }

        public ICommand SearchCommand { get; }
        
        private bool _isNavigating = false;
        
        public bool IsNavigating
        {
            get => _isNavigating;
            set => SetProperty(ref _isNavigating, value);
        }

        public JourneySearchViewModel(
            ITrainPointService trainPointService,
            INavigationService navigationService)
        {
            _trainPointService = trainPointService;
            _navigationService = navigationService;
            SearchCommand = new Command(OnSearch);
        }

        public async Task LoadDataAsync()
        {
            if (Stations.Count == 0)
            {
                var stations = await _trainPointService.GetAllStationsAsync();
                foreach (var station in stations)
                {
                    Stations.Add(station);
                }
            }

            if (Trains.Count == 0)
            {
                var trains = await _trainPointService.GetAllTrainsAsync();
                foreach (var train in trains)
                {
                    Trains.Add(train);
                }
            }
        }

        private async void OnSearch()
        {
            if (IsNavigating) return;

            IsNavigating = true; // Disable the button

            try
            {
                await _navigationService.NavigateToAsync<TwoStationsDetailPage>();
            }
            finally
            {
                IsNavigating = false; // Re-enable the button
            }
        }
    }
}

