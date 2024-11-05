namespace BanglaTracker.Core.Entities
{
    public class StationDetail
    {
        public string StationName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public double DistanceToNextStation { get; set; }
    }

}
