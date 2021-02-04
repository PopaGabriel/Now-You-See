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
        private List<Saved_Movie> NewMovies { set; get; }
        public MainPage()
        {
            InitializeComponent();
            Xamarin.Forms.Color BarBackgroundColor = ColorPallet.TextColorInfo;

            ProfileButton.TextColor = ColorPallet.TextColorButtons;
            ProfileButton.BackgroundColor = ColorPallet.BackgroundButton;

            BackgroundColor = ColorPallet.BackgroundMain;
            Image_Search.BackgroundColor = ColorPallet.BackgroundMain;

            FrameHotNewReleases.BackgroundColor = ColorPallet.BackgroundLabel;
            LabelInsideTheHotReleasesFrame.TextColor = ColorPallet.TextColorInfo;
            
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
            await Navigation.PushAsync(new ProfilePage());
        }
        private async void LetMeSeeTheMovie(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MoviePage(NewMovies[e.ItemIndex]));
        }
    }
}
