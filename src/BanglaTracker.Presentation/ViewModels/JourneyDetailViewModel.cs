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
                    ArrivalTime = DateTime.Now,
                    DepartureTime = DateTime.Now.AddMinutes(10),
                    DistanceToNextStation = 5.2
                },
                new StationDetail
                {
                    StationName = "Rajshahi",
                    ArrivalTime = DateTime.Now.AddMinutes(15),
                    DepartureTime = DateTime.Now.AddMinutes(25),
                    DistanceToNextStation = 7.3
                }
            };
        }
    }

}
