using BanglaTracker.Core.Entities;
using System.Collections.ObjectModel;

namespace BanglaTracker.Presentation.ViewModels
{    
    public class AllStationsDetailViewModel : BaseViewModel
    {
        private ObservableCollection<StationDetail> _stations;

        public ObservableCollection<StationDetail> Stations
        {
            get => _stations;
            set => SetProperty(ref _stations, value);
        }

        public AllStationsDetailViewModel()
        {
            Stations = new ObservableCollection<StationDetail>(GetSampleStationData());
        }

        public List<StationDetail> GetSampleStationData()
        {
            return new List<StationDetail>
            {
                new StationDetail { StationName = "Station A", ArrivalTime = "5 mins", BreakTime = "2 mins" },
                new StationDetail { StationName = "Station B", ArrivalTime = "10 mins", BreakTime = "3 mins" },
                new StationDetail { StationName = "Station C", ArrivalTime = "15 mins", BreakTime = "5 mins" },
            };
        }

    }

}
