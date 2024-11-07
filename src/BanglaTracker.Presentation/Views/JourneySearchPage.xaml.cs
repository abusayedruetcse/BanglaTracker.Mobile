using BanglaTracker.Presentation.ViewModels;

namespace BanglaTracker.Presentation.Views;

public partial class JourneySearchPage : ContentPage
{
    private JourneySearchViewModel ViewModel => BindingContext as JourneySearchViewModel;

    public JourneySearchPage(
        JourneySearchViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.LoadDataAsync(); // Load data when the page appears
    }

}

