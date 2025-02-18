namespace FluentHub.App.ViewModels.Repositories
{
    public class RepoContextViewModel : ObservableObject
    {
        private Repository _repository;
        public Repository Repository { get => _repository; set => SetProperty(ref _repository, value); }

        private string _branchName;
        public string BranchName { get => _branchName; set => SetProperty(ref _branchName, value); }

        private string _path;
        public string Path { get => _path; set => SetProperty(ref _path, value); }

        private bool _isDir;
        public bool IsDir
        {
            get => _isDir;
            set
            {
                if (value) IsFile = false;
                SetProperty(ref _isDir, value);
            }
        }

        private bool _isRootDir;
        public bool IsRootDir
        {
            get => _isRootDir;
            set
            {
                if (value) IsFile = false;
                SetProperty(ref _isRootDir, value);
            }
        }

        private bool _isSubDir;
        public bool IsSubDir
        {
            get => _isSubDir;
            set
            {
                if (value)
                {
                    IsDir = true;
                    IsFile = false;
                    IsRootDir = false;
                }
                SetProperty(ref _isSubDir, value);
            }
        }

        private bool _isFile;
        public bool IsFile
        {
            get => _isFile;
            set
            {
                if (value)
                {
                    IsRootDir = false;
                    IsDir = false;
                    IsSubDir = false;
                }
                SetProperty(ref _isFile, value);
            }
        }
    }
}
