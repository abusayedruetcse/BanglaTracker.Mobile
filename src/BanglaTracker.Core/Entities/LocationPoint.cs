using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanglaTracker.Core.Entities
{
    public class LocationPoint
    {
        public int Id { get; set; }            // Point number (1 through 10)
        public string Name { get; set; }        // Optional: descriptive name for the point
        public bool IsCrossed { get; set; }     // Indicates if the point has been crossed
        public bool IsCurrent { get; set; }     // Indicates if this is the current location

        public string StatusText => IsCurrent ? "Currently Here" : IsCrossed ? "Reached" : "Upcoming";
    }

}
