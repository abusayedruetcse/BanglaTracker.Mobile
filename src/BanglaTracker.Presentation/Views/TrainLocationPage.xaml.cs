using BanglaTracker.Presentation.ViewModels;

namespace BanglaTracker.Presentation.Views
{
    public partial class TrainLocationPage : ContentPage
    {
        public TrainLocationPage(TrainLocationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = BindingContext as TrainLocationViewModel;
            viewModel?.LoadTrainPointsCommand.Execute(null);
        }

    }
}