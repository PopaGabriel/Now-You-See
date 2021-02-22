using Proiecty_MLSA.Classes;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Paket;
using Proiecty_MLSA.Static_Values;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        public ObservableCollection<SavedMovie> GoodMovies { get; set; }
        public ObservableCollection<SavedMovie> BadMovies { get; set; }

        public ProfilePage()
        {
            InitializeComponent();

            GoodMovies = User.GetInstance().GoodMovies;
            ListGoodMovies.ItemsSource = GoodMovies;

            BadMovies = User.GetInstance().BadMovies;
            ListBadMovies.ItemsSource = BadMovies;

            ICommand refreshCommand = new Command(() =>
            {
                RefreshGood.IsRefreshing = false;
                RefreshBad.IsRefreshing = false;
            });
            RefreshGood.Command = refreshCommand;
            RefreshBad.Command = refreshCommand;

            Task.Run(() => ColorPallet.AnimateBackground(BoxView));
        }
        protected override void OnAppearing()
        {
            BoxView.Background = ColorPallet.GetBackground();
        }
        private async void ListMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is SavedMovie selectedMovie))
                return;

            if (User.GetInstance().Contains(selectedMovie)) await Navigation.PushAsync(new RatedMovie(selectedMovie));
            else await Navigation.PushAsync(new MoviePage(selectedMovie));

            ((CollectionView)sender).SelectedItem = null;
        }

        private void ThemeButton_Clicked(object sender, EventArgs e)
        { 
            Navigation.PushAsync(new ThemePage());
        }
    }
}