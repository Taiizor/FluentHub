using FluentHub.Octokit.Authorization;
using FluentHub.App.Models;
using FluentHub.App.Utils;
using Windows.System;

namespace FluentHub.App.ViewModels.SignIn
{
    public class IntroViewModel : ObservableObject
    {
        public IntroViewModel(ILogger logger = null)
        {
            _logger = logger;

            AuthorizeWithBrowserCommand = new AsyncRelayCommand<string>(AuthorizeWithBrowserAsync);
        }

        #region Fields and Properties
        private readonly ILogger _logger;

        private bool isLoading;
        public bool IsLoading { get => isLoading; set => SetProperty(ref isLoading, value); }

        private string authErrorMessage;
        public string AuthErrorMessage { get => authErrorMessage; set => SetProperty(ref authErrorMessage, value); }

        public IAsyncRelayCommand AuthorizeWithBrowserCommand { get; set; }
        #endregion

        private async Task AuthorizeWithBrowserAsync(string login, CancellationToken token)
        {
            try
            {
                var secrets = await Services.OctokitSecretsService.LoadOctokitSecretsAsync();

                AuthorizationService request = new();
                var url = request.RequestGitHubIdentityAsync(secrets);
                await Launcher.LaunchUriAsync(new Uri(url));

                App.AppSettings.SetupProgress = true;
                IsLoading = true;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                AuthErrorMessage = ex.Message;
                App.AppSettings.SetupProgress = false;

                _logger?.Error(nameof(AuthorizeWithBrowserAsync), ex);
                throw;
            }
        }
    }
}
