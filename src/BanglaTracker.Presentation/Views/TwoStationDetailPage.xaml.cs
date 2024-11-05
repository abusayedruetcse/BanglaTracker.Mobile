using BanglaTracker.Presentation.ViewModels;

namespace BanglaTracker.Presentation.Views;

public partial class TwoStationDetailPage : ContentPage
{
	public TwoStationDetailPage()
	{
		InitializeComponent();
        BindingContext = new JourneyDetailViewModel(); // Set the ViewModel as BindingContext
    }
}