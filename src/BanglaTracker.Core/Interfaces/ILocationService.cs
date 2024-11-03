using BanglaTracker.Core.DTOs;
using BanglaTracker.Core.Entities;
using BanglaTracker.Core.Requests;

namespace BanglaTracker.Core.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationPoint>> GetTrainPointsAsync();

        Task SendGeolocationDataAsync(LocationData locationData);

        Task UpdateLastActiveTimeAsync(UserLastActiveDto requestDto);

        Task<JourneyResponseDto> StartJourneyAsync(StartJourneyRequest startJourneyRequest);
    }
}
