using Proiecty_MLSA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public List<Saved_Movie> GoodMovies { get; set; }
        public List<Saved_Movie> BadMovies { get; set; }
        public ProfilePage()
        {
            InitializeComponent();
            GoodMovies = User.getInstance().GoodMovies;
            Console.Out.WriteLine(GoodMovies.Count);
            ListGoodMovies.ItemsSource = GoodMovies;

            BadMovies = User.getInstance().BadMovies;
            ListBadMovies.ItemsSource = BadMovies;
        }
        public async void ShowAllMovies(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        public async void ShowBadMovies(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MoviePage(BadMovies[e.ItemIndex]));
        }

        private async void ListGoodMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.Out.WriteLine("De ce nu mergi?");
            var SavedMovieInstance = e.CurrentSelection.FirstOrDefault() as Saved_Movie;
            
            if (SavedMovieInstance == null)
                return;
            Console.Out.WriteLine("De ce nu mergi?");
            await Navigation.PushAsync(new MoviePage(SavedMovieInstance));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}