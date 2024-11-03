using BanglaTracker.Core.DTOs;
using BanglaTracker.Core.Entities;

namespace BanglaTracker.Core.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationPoint>> GetTrainPointsAsync();

        Task SendGeolocationDataAsync(LocationData locationData);

        Task<JourneyResponseDto> StartJourneyAsync(LocationData locationData);
    }
}
