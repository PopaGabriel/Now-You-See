using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        public ObservableCollection<Genre> genres { get; set; }
        public MoviePage(Saved_Movie Movielet)
        {
            InitializeComponent();
            MovieStack.BindingContext = Movielet;
            genres = new ObservableCollection<Genre>(Movielet.genres);
            Carousel.ItemsSource = genres;
        }
        public void AddToUserList(object sender, EventArgs e)
        {

        }
        public void RemoveFromUserList(object sender, EventArgs e)
        {

        }
    }
}