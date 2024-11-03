using BanglaTracker.Core.Constants;

namespace BanglaTracker.Presentation.Utils
{
    public class InstallationIdProvider
    {        
        public static Guid GetInstallationId()
        {
            // Attempt to retrieve the ID from preferences
            var storedId = Preferences.Get(AppSettingsConstants.app_installation_id, string.Empty);

            // If no ID is found, generate a new one and save it
            if (string.IsNullOrEmpty(storedId))
            {
                var newId = Guid.NewGuid();
                Preferences.Set(AppSettingsConstants.app_installation_id, newId.ToString());
                return newId;
            }

            // Return the existing ID if found
            return Guid.Parse(storedId);
        }
    }

}
