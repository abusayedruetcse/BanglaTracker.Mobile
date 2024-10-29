using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BanglaTracker.BLL.Services
{
    public class TrainPointService : ITrainPointService
    {
        private readonly ILocationService _locationService;

        public TrainPointService(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<List<LocationPoint>> GetTrainPointsAsync()
        {
            var trainPoints = new List<LocationPoint>
            {
                new LocationPoint { Id = 1, Name = "Point 1", IsCrossed = true},
                new LocationPoint { Id = 2, Name = "Point 2", IsCrossed = true},
                new LocationPoint { Id = 1, Name = "Point 1", IsCrossed = true},
                new LocationPoint { Id = 2, Name = "Point 2", IsCrossed = true},
                new LocationPoint { Id = 1, Name = "Point 1", IsCrossed = true},
                new LocationPoint { Id = 2, Name = "Point 2", IsCrossed = true},
                new LocationPoint { Id = 3, Name = "Point 3", IsCrossed = false, IsCurrent = true },
                new LocationPoint { Id = 4, Name = "Point 4", IsCrossed = false},
                new LocationPoint { Id = 5, Name = "Point 5", IsCrossed = false},
                new LocationPoint { Id = 6, Name = "Point 6", IsCrossed = false},
                new LocationPoint { Id = 7, Name = "Point 7", IsCrossed = false},
                new LocationPoint { Id = 8, Name = "Point 8", IsCrossed = false},
                new LocationPoint { Id = 9, Name = "Point 9", IsCrossed = false},
                new LocationPoint { Id = 10, Name = "Point 10", IsCrossed = false},
                new LocationPoint { Id = 5, Name = "Point 5", IsCrossed = false},
                new LocationPoint { Id = 6, Name = "Point 6", IsCrossed = false},
                new LocationPoint { Id = 7, Name = "Point 7", IsCrossed = false},
                new LocationPoint { Id = 8, Name = "Point 8", IsCrossed = false},
                new LocationPoint { Id = 9, Name = "Point 9", IsCrossed = false},
                new LocationPoint { Id = 10, Name = "Point 10", IsCrossed = false},
            };

            return trainPoints;
            
            var response = await _locationService.GetTrainPointsAsync();
            return response ?? new List<LocationPoint>();
        }

        public async Task SendGeolocationDataAsync(LocationData locationData)
        {           
            await _locationService.SendGeolocationDataAsync(locationData);
        }
    }
}
