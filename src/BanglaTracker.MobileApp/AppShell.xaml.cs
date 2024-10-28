using BanglaTracker.Presentation.Views;

namespace BanglaTracker.MobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Register the route for TrainLocationPage
            Routing.RegisterRoute(nameof(TrainLocationPage1), typeof(TrainLocationPage1));
        }
    }
}
