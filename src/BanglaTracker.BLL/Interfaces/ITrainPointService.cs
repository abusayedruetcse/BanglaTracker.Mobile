using BanglaTracker.Core.DTOs;
using BanglaTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanglaTracker.BLL.Interfaces
{
    public interface ITrainPointService
    {
        Task<List<LocationPoint>> GetTrainPointsAsync();

        Task SendGeolocationDataAsync(LocationData locationData);

        Task<JourneyResponseDto> StartJourneyAsync(
            string fromStation,
            string toStation,
            string trainName,
            string currentStation,
            Guid installationID);

        Task<List<Train>> GetAllTrainsAsync();

        Task<List<Station>> GetAllStationsAsync();
    }
}
