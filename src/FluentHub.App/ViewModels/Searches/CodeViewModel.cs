using FluentHub.Octokit.Searches;
using FluentHub.App.Helpers;
using FluentHub.App.Models;
using FluentHub.App.Services;
using FluentHub.App.Utils;
using FluentHub.App.ViewModels.UserControls.BlockButtons;
using FluentHub.App.ViewModels.UserControls.Overview;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;

namespace FluentHub.App.ViewModels.Searches
{
    public class CodeViewModel : ObservableObject
    {
        public CodeViewModel(IMessenger messenger = null, ILogger logger = null)
        {
            _messenger = messenger;
            _logger = logger;

            _resultItems = new();
            ResultItems = new(_resultItems);

            LoadSearchCodePageCommand = new AsyncRelayCommand(LoadSearchCodePageAsync);
        }

        #region Fields and Properties
        private readonly ILogger _logger;
        private readonly IMessenger _messenger;

        private int _loadedItemCount = 0;
        private int _loadedPageCount = 0;
        private bool _loadedToTheEnd = false;
        private const int _itemCountPerPage = 30;

        private string _searchTerm;
        public string SearchTerm { get => _searchTerm; set => SetProperty(ref _searchTerm, value); }

        private readonly ObservableCollection<FluentHub.Octokit.Models.v3.Searches.SearchCode> _resultItems;
        public ReadOnlyObservableCollection<FluentHub.Octokit.Models.v3.Searches.SearchCode> ResultItems { get; }

        private Exception _taskException;
        public Exception TaskException { get => _taskException; set => SetProperty(ref _taskException, value); }

        public IAsyncRelayCommand LoadSearchCodePageCommand { get; }
        #endregion

        private async Task LoadSearchCodePageAsync()
        {
            _messenger?.Send(new TaskStateMessaging(TaskStatusType.IsStarted));
            bool faulted = false;

            string _currentTaskingMethodName = nameof(LoadSearchCodePageAsync);

            try
            {
                _currentTaskingMethodName = nameof(LoadSearchResultsAsync);
                await LoadSearchResultsAsync(SearchTerm);
            }
            catch (Exception ex)
            {
                TaskException = ex;
                faulted = true;

                _logger?.Error(_currentTaskingMethodName, ex);
                throw;
            }
            finally
            {
                SetCurrentTabItem();

                _messenger?.Send(new TaskStateMessaging(faulted ? TaskStatusType.IsFaulted : TaskStatusType.IsCompletedSuccessfully));
            }
        }

        private async Task LoadSearchResultsAsync(string term)
        {
            if (_loadedToTheEnd)
                return;

            CodeSearches searches = new();
            var response = await searches.GetAllAsync(term);

            _loadedItemCount += response.Count;
            _loadedPageCount++;

            // TODO: Fix this
            if (response.Count < 100)
                _loadedToTheEnd = true;

            _resultItems.Clear();
            foreach (var item in response)
            {
                _resultItems.Add(item);
            }
        }

        public async Task LoadFurtherSearchResultsAsync()
        {
            // TODO: Fix RepoSearchQuery.cs to allow for custom api options
        }

        private void SetCurrentTabItem()
        {
            var provider = App.Current.Services;
            INavigationService navigationService = provider.GetRequiredService<INavigationService>();

            var currentItem = navigationService.TabView.SelectedItem.NavigationHistory.CurrentItem;
            currentItem.Header = "Repository Results";
            currentItem.Description = "Repository Results for \"" + SearchTerm + "\"";
            currentItem.Icon = new ImageIconSource
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Icons/Search.png"))
            };
        }
    }
}
