using BanglaTracker.BLL.Interfaces;
using BanglaTracker.Core.Constants;
using BanglaTracker.Presentation.Utils;

namespace BanglaTracker.MobileApp
{
    public partial class App : Application
    {

        public App(
            AppShell appShell,
            IUserService userService)
        {
            InitializeComponent();
            
            // Inform last activity time
            userService.UpdateLastActiveTimeAsync(InstallationIdProvider.GetInstallationId());

            // Set the injected AppShell instance as the MainPage
            MainPage = appShell;
        }
    }
}
