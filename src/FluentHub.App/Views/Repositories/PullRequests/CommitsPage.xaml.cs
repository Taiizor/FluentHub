using FluentHub.App.Models;
using FluentHub.App.Services;
using FluentHub.App.ViewModels.Repositories.PullRequests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;

namespace FluentHub.App.Views.Repositories.PullRequests
{
    public sealed partial class CommitsPage : Page
    {
        public CommitsPage()
        {
            InitializeComponent();

            var provider = App.Current.Services;
            ViewModel = provider.GetRequiredService<CommitsViewModel>();
            _navigation = provider.GetRequiredService<INavigationService>();
        }

        public CommitsViewModel ViewModel { get; }
        private readonly INavigationService _navigation;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as FrameNavigationArgs;
            ViewModel.Login = param.Login;
            ViewModel.Name = param.Name;
            ViewModel.Number = param.Number;

            var command = ViewModel.LoadRepositoryPullRequestCommitsPageCommand;
            if (command.CanExecute(null))
                command.Execute(null);
        }
    }
}
