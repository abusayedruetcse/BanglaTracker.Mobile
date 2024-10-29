using BanglaTracker.Presentation.ViewModels;
using BanglaTracker.Presentation.Views;

namespace BanglaTracker.MobileApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        
        private readonly IServiceProvider _serviceProvider;

        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider; 
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnOpenTrainLocationPageClicked(object sender, EventArgs e)
        {
            // Resolve TrainLocationPage with TrainLocationViewModel from the DI container
            var trainLocationPage = _serviceProvider.GetRequiredService<TrainLocationPage>();

            // Navigate to TrainLocationPage
            await Navigation.PushAsync(trainLocationPage);
        }

        private async void OnOpenTrackingLocationBtnClicked(object sender, EventArgs e)
        {
            // Resolve TrainLocationPage with TrainLocationViewModel from the DI container
            var trackingLocationPage = _serviceProvider.GetRequiredService<TrainTrackingPage>();

            // Navigate to TrainLocationPage
            await Navigation.PushAsync(trackingLocationPage);
        }

        private async void OnCounterClicked1(object sender, EventArgs e)
        {
            // Navigate to TrainLocationPage
            await Shell.Current.GoToAsync(nameof(TrainLocationPage1));
        }

    }

}
