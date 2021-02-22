using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatedMovie
    {
        public SavedMovie movie { set; get; }
        public ObservableCollection<Genre> Genres { get; set; }
        public RatedMovie(SavedMovie movie)
        {
            InitializeComponent();
            MovieStack.BindingContext = movie;
            this.movie = movie;
            Genres = new ObservableCollection<Genre>(movie.genres);
            Title = movie.title;

            BoxView.Background = ColorPallet.GetBackground();
            Task.Run(() => ColorPallet.AnimateBackground(BoxView));
            Carousel.ItemsSource = Genres;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            User.GetInstance().GoodMovies.Remove(movie);
            User.GetInstance().BadMovies.Remove(movie);
            await Navigation.PopAsync();
        }
    }
}