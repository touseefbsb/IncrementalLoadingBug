using IncrementalLoadingBug.Models;
using IncrementalLoadingBug.ViewModels;
using Microsoft.Toolkit.Uwp;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IncrementalLoadingBug
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();
        public MainPage() => InitializeComponent();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var collection = new IncrementalLoadingCollection<PeopleSource, Person>();

            PeopleListView.ItemsSource = collection;

        }

    }
}
