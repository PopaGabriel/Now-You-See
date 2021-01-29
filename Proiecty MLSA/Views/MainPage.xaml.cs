using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using Proiecty_MLSA.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proiecty_MLSA
{
    public partial class MainPage : ContentPage
    {
        private List<Movie> NewMovies { set; get; }
        public MainPage()
        {
            InitializeComponent();

            Task.Run(() => makePopularMovies());

        }
        public void makePopularMovies()
        {
            ApiHelper apiHelper = ApiHelper.getInstance();

            if (NewMovies == null)
            {
                NewMovies = apiHelper.GetPopularMovies().Result;

                ListViewMainPage.ItemsSource = NewMovies;
                BindingContext = this;
            }

        }
        private async void Recomanda(object sender, EventArgs e)
        {
            
            Console.Out.WriteLine(User.getInstance() + "\nDE ce?");

            if (Device.RuntimePlatform == Device.Android)
                await Navigation.PopAsync();
        }
        private async void GoToProfilePage(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ProfilePage(user));
        }
        private async void LetMeSeeTheMovie(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MoviePage(NewMovies[e.ItemIndex]));
        }
    }
}
