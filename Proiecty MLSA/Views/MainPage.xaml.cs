using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using Proiecty_MLSA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proiecty_MLSA
{
    public partial class MainPage
    {
        private List<Saved_Movie> NewMovies { set; get; }
        public MainPage()
        {
            Task.Run(MakePopularMovies);

            InitializeComponent();

            ICommand refreshCommand = new Command(() =>
            {
                RefreshMain.IsRefreshing = false;
            });
            RefreshMain.Command = refreshCommand;

        }
        public void MakePopularMovies()
        {
            var apiHelper = ApiHelper.getInstance();

            if (NewMovies != null) return;

            NewMovies = apiHelper.GetPopularMovies().Result;
            CollectionViewMainPage.ItemsSource = NewMovies;
            BindingContext = this;

        }

        protected override void OnAppearing()
        {
            StackMain.Background = ColorPallet.GetBackground();
        }
        private async void Recomanda(object sender, EventArgs e)
        {

            await Console.Out.WriteLineAsync(User.getInstance() + "\nDE ce?");

            if (Device.RuntimePlatform == Device.Android)
                await Navigation.PopAsync();
        }
        private async void GoToProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void CollectionViewMainPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is Saved_Movie selectedMovie))
                return;

            await Navigation.PushAsync(new MoviePage(selectedMovie));

            ((CollectionView)sender).SelectedItem = null;

        }
        private async void SearchButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPageXama("Search...."));
        }
    }
}
