using FluentHub.App.Extensions;
using FluentHub.App.Services;
using FluentHub.App.Models;
using FluentHub.App.ViewModels.Repositories.Releases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Web.WebView2.Core;

namespace FluentHub.App.Views.Repositories.Releases
{
    public sealed partial class ReleasePage : Page
    {
        public ReleasePage()
        {
            InitializeComponent();

            var provider = App.Current.Services;
            ViewModel = provider.GetRequiredService<ReleaseViewModel>();
            _navigation = App.Current.Services.GetRequiredService<INavigationService>();
        }

        public ReleaseViewModel ViewModel { get; }
        private readonly INavigationService _navigation;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as FrameNavigationArgs;
            _ = param ?? throw new ArgumentNullException("param");

            ViewModel.Login = param.Login;
            ViewModel.Name = param.Name;
            ViewModel.TagName = param.Parameters.ElementAtOrDefault(0) as string;

            var command = ViewModel.LoadRepositoryReleasePageCommand;
            if (command.CanExecute(null))
                command.Execute(null);
        }

        private void OnSingleReleaseWebView2Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ReleaseDescriptionWebView2 = SingleReleaseWebView2;
        }

        private async void OnSingleReleaseWebView2NavigationCompleted(WebView2 sender, CoreWebView2NavigationCompletedEventArgs args)
            => await sender.HandleResize();

        private async void OnSingleReleaseWebView2SizeChanged(object sender, SizeChangedEventArgs e)
            => await ((WebView2)sender).HandleResize();
    }
}
