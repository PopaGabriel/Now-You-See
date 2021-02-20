using Proiecty_MLSA.Classes;
using System;
using System.Collections.ObjectModel;
using Proiecty_MLSA.Static_Values;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage
    {
        public ObservableCollection<Genre> Genres { get; set; }
        public MoviePage(Movie movie)
        {
            InitializeComponent();
            MovieStack.BindingContext = movie;
            Genres = new ObservableCollection<Genre>(movie.genres);
            Title = movie.title;

            Carousel.ItemsSource = Genres;
        }
        protected override void OnAppearing()
        {
            FrameStack.Background = ColorPallet.GetBackground();
        }
        public void AddToUserList(object sender, EventArgs e)
        {

        }
        public void RemoveFromUserList(object sender, EventArgs e)
        {

        }
    }
}