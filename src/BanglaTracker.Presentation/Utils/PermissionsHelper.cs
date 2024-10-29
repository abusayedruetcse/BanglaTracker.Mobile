using static Microsoft.Maui.ApplicationModel.Permissions;

namespace BanglaTracker.Presentation.Utils
{
    public static class PermissionsHelper
    {
        public static async Task<bool> RequestLocationPermissions()
        {
            var status = await Permissions.CheckStatusAsync<LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<LocationWhenInUse>();
            }

            return status == PermissionStatus.Granted;
        }
    }

}
