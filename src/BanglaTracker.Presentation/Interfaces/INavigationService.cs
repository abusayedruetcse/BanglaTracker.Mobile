namespace BanglaTracker.Presentation.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync<TPage>() where TPage : Page;
    }
}
