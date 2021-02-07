using Paket;
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
    public partial class MainPage : ContentPage
    {
        private List<Saved_Movie> NewMovies { set; get; }
        public MainPage()
        {
            InitializeComponent();
            InitializeComponentColors();
            
            Task.Run(() => makePopularMovies());
            
            ICommand refreshCommand = new Command(() =>
            {
                RefreshMain.IsRefreshing = false;
            });
            RefreshMain.Command = refreshCommand;
            
        }
        private void InitializeComponentColors()
        {
            
            NavigationBar.CancelButtonColor = ColorPallet.TextColorInfo;
            NavigationBar.TextColor = ColorPallet.TextColorInfo;
            NavigationBar.PlaceholderColor = ColorPallet.TextColorInfo;
            ProfileButton.TextColor = ColorPallet.TextColorInfo;
            ProfileButton.BackgroundColor = ColorPallet.BackgroundButton;
            BackgroundColor = ColorPallet.BackgroundMain;
            Image_Search.BackgroundColor = ColorPallet.BackgroundMain;
            NavigationBar.BackgroundColor = ColorPallet.BackgroundButton;
            ÇollectionViewMainPage.BackgroundColor = ColorPallet.BackgroundButton;
            LabelInsideTheHotReleasesFrame.BackgroundColor = ColorPallet.BackgroundMain;
            LabelInsideTheHotReleasesFrame.TextColor = ColorPallet.TextColorInfo;
        }
        public void makePopularMovies()
        {
            ApiHelper apiHelper = ApiHelper.getInstance();

            if (NewMovies == null)
            {
                NewMovies = apiHelper.GetPopularMovies().Result;

                ÇollectionViewMainPage.ItemsSource = NewMovies;
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

        private async void CollectionViewMainPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedMovie = e.CurrentSelection.FirstOrDefault() as Saved_Movie;
            if (SelectedMovie == null)
                return;

            await Navigation.PushAsync(new MoviePage(SelectedMovie));

            ((CollectionView)sender).SelectedItem = null;

        }
    }
}
