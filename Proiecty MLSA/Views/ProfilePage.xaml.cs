using Proiecty_MLSA.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        User user { set; get; }
        public ProfilePage(User user)
        {
            this.user = user;
            InitializeComponent();
            ListGoodMovies.ItemsSource = user.GoodMovies;
            ListBadMovies.ItemsSource = user.BadMovies;
            BindingContext = this;
        }
        public async void ShowAllMovies(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        public async void ShowGoodMovies(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MoviePage(user.GoodMovies[e.ItemIndex]));
        }
        public async void ShowBadMovies(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MoviePage(user.BadMovies[e.ItemIndex]));
        }
    }
}