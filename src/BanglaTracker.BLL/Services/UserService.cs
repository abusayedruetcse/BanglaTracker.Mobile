using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Core.DTOs;
using BanglaTracker.Core.Entities;
using BanglaTracker.Core.Interfaces;

namespace BanglaTracker.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ILocationService _locationService;

        public UserService(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task UpdateLastActiveTimeAsync(string installationId)
        {
            var modelDto = new UserLastActiveDto()
            {
                InstallationID = installationId,
                LastActiveTime = DateTime.UtcNow
            };

            await _locationService.UpdateLastActiveTimeAsync(modelDto);
        }

    }
}
