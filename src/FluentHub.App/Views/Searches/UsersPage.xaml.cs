using FluentHub.App.Services;
using FluentHub.App.ViewModels.Searches;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;

namespace FluentHub.App.Views.Searches
{
    public sealed partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();

            var provider = App.Current.Services;
            ViewModel = provider.GetRequiredService<UsersViewModel>();
        }

        public UsersViewModel ViewModel { get; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as Models.FrameNavigationArgs;
            ViewModel.SearchTerm = param.Parameters.ElementAtOrDefault(0) as string;

            var command = ViewModel.LoadSearchUsersPageCommand;
            if (command.CanExecute(null))
                command.ExecuteAsync(null);
        }
    }
}
