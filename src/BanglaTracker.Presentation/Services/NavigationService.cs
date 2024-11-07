using BanglaTracker.Presentation.Interfaces;

namespace BanglaTracker.Presentation.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task NavigateToAsync<TPage>() where TPage : Page
        {
            var page = _serviceProvider.GetRequiredService<TPage>();
            
            if (page != null && Application.Current?.MainPage?.Navigation != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }
    }

}
