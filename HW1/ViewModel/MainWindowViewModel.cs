using CSharpHomework.Tools;
using System.Windows;
using CSharpHomework.Tools.DataStorage;
using CSharpHomework.Tools.Managers;
using CSharpHomework.Tools.Navigation;

namespace CSharpHomework.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner, IContentOwner
    {

        #region Fields
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        private INavigatable _content;
        #endregion

        #region Properties
        public INavigatable Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion


        internal MainWindowViewModel()
        {
            StationManager.Initialize(new SerializedDataStorage());
            LoaderManager.Instance.Initialize(this);
            NavigationManager.Instance.Initialize(new AuthenticationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);

        }

    }
}
