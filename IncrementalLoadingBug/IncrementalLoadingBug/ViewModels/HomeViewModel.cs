using IncrementalLoadingBug.Helpers;
using System.Windows.Input;

namespace IncrementalLoadingBug.ViewModels
{
    public class HomeViewModel
    {

        #region Fields
        private ICommand _loadedCommand;
        private ICommand _unLoadedCommand;
        #endregion

        #region Props

        public AppViewModel AppVM => App.AppVM;
        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));
        public ICommand UnLoadedCommand => _unLoadedCommand ?? (_unLoadedCommand = new RelayCommand(OnUnLoaded));

        private void OnUnLoaded() { }
        #endregion

        #region Methods
        private async void OnLoaded()
        {
            AppVM.TopListViewItem = null;
            await AppVM.LoadDataAsync();
        }
        #endregion
    }
}
