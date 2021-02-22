using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using Proiecty_MLSA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Lottie.Forms;
using Xamarin.Forms;

namespace Proiecty_MLSA
{
    public partial class MainPage
    {
        private List<SavedMovie> NewMovies { set; get; }
        public MainPage()
        {
            Task.Run(MakePopularMovies);
            InitializeComponent();
            Task.Run(() => ColorPallet.AnimateBackground(BoxView));
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
            AnimationView.Animation = "Movie.json";
            BoxView.Background = ColorPallet.GetBackground();
        }
        private async void GoToProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void CollectionViewMainPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is SavedMovie selectedMovie))
                return;

            if (User.GetInstance().Contains(selectedMovie)) await Navigation.PushAsync(new RatedMovie(selectedMovie));
            else await Navigation.PushAsync(new MoviePage(selectedMovie));

            ((CollectionView)sender).SelectedItem = null;

        }
        private async void SearchButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPageXama());
        }

        private async void AnimationView_OnOnClick(object sender, EventArgs e)
        {
            AnimationView.PlayFrameSegment(44, 60);
            await Task.Delay(700);
            AnimationView.Animation = "MainButton.json";
            //await Task.Delay(5000);
            await Navigation.PushAsync(new SearchPageXama(await ApiHelper.getInstance().Recommend()));
        }
    }
}
