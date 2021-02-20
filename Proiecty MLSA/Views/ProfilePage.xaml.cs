using Proiecty_MLSA.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Proiecty_MLSA.Static_Values;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        public ObservableCollection<Saved_Movie> GoodMovies { get; set; }
        public ObservableCollection<Saved_Movie> BadMovies { get; set; }

        public ProfilePage()
        {
            InitializeComponent();

            GoodMovies = User.getInstance().GoodMovies;
            ListGoodMovies.ItemsSource = GoodMovies;

            BadMovies = User.getInstance().BadMovies;
            ListBadMovies.ItemsSource = BadMovies;

            ICommand refreshCommand = new Command(() =>
            {
                RefreshGood.IsRefreshing = false;
                RefreshBad.IsRefreshing = false;
            });
            RefreshGood.Command = refreshCommand;
            RefreshBad.Command = refreshCommand;
        }
        protected override void OnAppearing()
        {
            StackLayoutProfilePage.Background = ColorPallet.getBackground();
        }
        private async void ListMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var savedMovieInstance = e.CurrentSelection.FirstOrDefault() as Saved_Movie;

            if (savedMovieInstance == null)
                return;

            await Navigation.PushAsync(new MoviePage(savedMovieInstance));

            ((CollectionView)sender).SelectedItem = null;
        }

        private async void ThemeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThemePage());
        }
    }
}