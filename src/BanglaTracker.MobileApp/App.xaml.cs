using BanglaTracker.Core.Constants;

namespace BanglaTracker.MobileApp
{
    public partial class App : Application
    {
        public App(AppShell appShell)
        {
            InitializeComponent();

            // Check if app_installation_id exists; if not, create and save a new one.
            if (!Preferences.ContainsKey(AppSettingsConstants.app_installation_id))
            {
                var newInstallationId = Guid.NewGuid().ToString();
                Preferences.Set(AppSettingsConstants.app_installation_id, newInstallationId);
            }

            // Set the injected AppShell instance as the MainPage
            MainPage = appShell;
        }
    }
}
