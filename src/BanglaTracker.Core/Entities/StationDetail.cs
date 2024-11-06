namespace BanglaTracker.Core.Entities
{
    public class StationDetail
    {
        public string StationName { get; set; }
        public string ArrivalTime { get; set; }
        public string BreakTime { get; set; }
        public string DepartureTime { get; set; }
        public double DistanceToNextStation { get; set; }
    }

}
