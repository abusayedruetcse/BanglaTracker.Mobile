namespace BanglaTracker.MobileApp
{
    public partial class App : Application
    {
        public App(AppShell appShell)
        {
            InitializeComponent();

            // Set the injected AppShell instance as the MainPage
            MainPage = appShell;
        }
    }
}
