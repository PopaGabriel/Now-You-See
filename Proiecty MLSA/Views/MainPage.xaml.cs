using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proiecty_MLSA
{
    public partial class MainPage : ContentPage
    {
        private List<Movie> NewMovies { set; get; }
        private User user;
        public MainPage()
        {
            InitializeComponent();
            NewMovies = new List<Movie>();
            NewMovies.Add(new Movie("The Shawshank Redemption", 1));
            NewMovies[0].Image = "bed_double_fill.jpg";
            NewMovies[0].Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.";
            for (int i = 0; i < 15; i++)
                NewMovies[0].Team.Add(new Worker());

            NewMovies.Add(new Movie("The Godfather", 2));
            NewMovies[1].Image = "bed_double_fill.jpg";
            NewMovies[1].Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son";
            for (int i = 0; i < 15; i++)
                NewMovies[1].Team.Add(new Worker());

            NewMovies.Add(new Movie("Pulp Fiction", 3));
            NewMovies[2].Image = "bed_double_fill.jpg";
            NewMovies[2].Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.";
            for (int i = 0; i < 15; i++)
                NewMovies[2].Team.Add(new Worker());

            NewMovies.Add(new Movie("Fight Club", 4));
            NewMovies[3].Image = "bed_double_fill.jpg";
            NewMovies[3].Description = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.";
            for (int i = 0; i < 15; i++)
                NewMovies[3].Team.Add(new Worker());

            NewMovies.Add(new Movie("Inception", 5));
            NewMovies[4].Image = "bed_double_fill.jpg";
            NewMovies[4].Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.";
            for (int i = 0; i < 15; i++)
                NewMovies[4].Team.Add(new Worker());

            Console.WriteLine(NewMovies);
            ListViewMainPage.ItemsSource = NewMovies;

            user = new User();
            BindingContext = this;
        }
        private async void Recomanda(object sender, EventArgs e)
        {
            Console.WriteLine("Merge_fratelelelelelele");
            if (Device.RuntimePlatform == Device.Android)
                await Navigation.PopAsync();
        }
        private async void GoToProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(user));
        }
        private async void LetMeSeeTheMovie(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MoviePage(NewMovies[e.ItemIndex]));
        }
    }
}
