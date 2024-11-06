using BanglaTracker.Presentation.ViewModels;

namespace BanglaTracker.Presentation.Views;

public partial class TwoStationsDetailPage : ContentPage
{
	public TwoStationsDetailPage()
	{
		InitializeComponent();
        BindingContext = new JourneyDetailViewModel(); // Set the ViewModel as BindingContext
    }
}