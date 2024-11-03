namespace BanglaTracker.Presentation.Utils
{
    public class InstallationIdProvider
    {
        public static string GetInstallationId()
        {
            return Preferences.Get("app_installation_id", string.Empty);
        }
    }
}
