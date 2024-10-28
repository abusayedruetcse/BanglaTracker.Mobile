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
        private readonly HttpClient _httpClient;

        public TrainPointService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TrainPoint>> GetTrainPointsAsync()
        {
            var trainPoints = new List<TrainPoint>
            {
                new TrainPoint { Id = 1, Name = "Point 1", IsCrossed = true, IsCurrent = false },
                new TrainPoint { Id = 2, Name = "Point 2", IsCrossed = true, IsCurrent = false },
                new TrainPoint { Id = 1, Name = "Point 1", IsCrossed = true, IsCurrent = false },
                new TrainPoint { Id = 2, Name = "Point 2", IsCrossed = true, IsCurrent = false },
                new TrainPoint { Id = 1, Name = "Point 1", IsCrossed = true, IsCurrent = false },
                new TrainPoint { Id = 2, Name = "Point 2", IsCrossed = true, IsCurrent = false },
                new TrainPoint { Id = 3, Name = "Point 3", IsCrossed = false, IsCurrent = true },
                new TrainPoint { Id = 4, Name = "Point 4", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 5, Name = "Point 5", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 6, Name = "Point 6", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 7, Name = "Point 7", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 8, Name = "Point 8", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 9, Name = "Point 9", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 10, Name = "Point 10", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 5, Name = "Point 5", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 6, Name = "Point 6", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 7, Name = "Point 7", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 8, Name = "Point 8", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 9, Name = "Point 9", IsCrossed = false, IsCurrent = false },
                new TrainPoint { Id = 10, Name = "Point 10", IsCrossed = false, IsCurrent = false },
            };

            return trainPoints;
            //var response = await _httpClient.GetFromJsonAsync<List<TrainPoint>>("https://api.example.com/train/points");
            //return response ?? new List<TrainPoint>();
        }
    }
}
