using BanglaTracker.BLL.Services;
using BanglaTracker.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BanglaTracker.Presentation.ViewModels
{
    public partial class TrainLocationViewModel : ObservableObject
    {
        private readonly TrainPointService _trainPointService;

        public ObservableCollection<TrainPoint> Points { get; set; } = new();

        public TrainLocationViewModel(TrainPointService trainPointService)
        {
            _trainPointService = trainPointService;
            LoadTrainPointsCommand = new AsyncRelayCommand(LoadTrainPointsAsync);
        }

        public IAsyncRelayCommand LoadTrainPointsCommand { get; }

        private async Task LoadTrainPointsAsync()
        {
            // Clear existing points if any
            Points.Clear();

            // Fetch points from API
            var pointsFromApi = await _trainPointService.GetTrainPointsAsync();

            // Add fetched points to the ObservableCollection
            foreach (var point in pointsFromApi)
            {
                Points.Add(point);
            }
        }
    }

}
