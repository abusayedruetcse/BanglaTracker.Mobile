using BanglaTracker.Core.Entities;
using System.Collections.ObjectModel;

namespace BanglaTracker.Presentation.ViewModels
{
    public class JourneyDetailViewModel : BaseViewModel
    {
        public ObservableCollection<StationDetail> StationDetails { get; }

        public JourneyDetailViewModel()
        {
            // Initialize with two stations - current and next
            StationDetails = new ObservableCollection<StationDetail>
            {
                new StationDetail
                {
                    StationName = "Dhaka",
                    ArrivalTime = "5 mins",
                    DepartureTime = "15 mins",
                    DistanceToNextStation = 5.2
                },
                new StationDetail
                {
                    StationName = "Rajshahi",
                    ArrivalTime = "5 mins",
                    DepartureTime = "15 mins",
                    DistanceToNextStation = 7.3
                }
            };
        }
    }

}
