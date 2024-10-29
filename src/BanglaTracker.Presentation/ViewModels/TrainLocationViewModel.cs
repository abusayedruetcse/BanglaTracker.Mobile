using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BanglaTracker.Presentation.ViewModels
{
    public partial class TrainLocationViewModel : ObservableObject
    {
        private readonly ITrainPointService _trainPointService;

        public ObservableCollection<LocationPoint> Points { get; set; } = new();

        public TrainLocationViewModel(ITrainPointService trainPointService)
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
