using BanglaTracker.Presentation.ViewModels;

namespace BanglaTracker.Presentation.Views;

public partial class AllStationsDetailPage : ContentPage
{
	public AllStationsDetailPage(
		AllStationsDetailViewModel allStationsDetailViewModel)
	{
		InitializeComponent();
        BindingContext = allStationsDetailViewModel;
    }
}