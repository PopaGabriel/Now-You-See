using Proiecty_MLSA.Classes;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Proiecty_MLSA.Static_Values;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage
    {
        public ObservableCollection<Genre> Genres { get; set; }

        private SavedMovie movie { set; get; }
        public MoviePage(Movie movie)
        {
            InitializeComponent();
            MovieStack.BindingContext = movie;
            this.movie = (SavedMovie) movie;
            Genres = new ObservableCollection<Genre>(movie.genres);
            Title = movie.title;

            BoxView.Background = ColorPallet.GetBackground();
            Task.Run(() => ColorPallet.AnimateBackground(BoxView));
            Carousel.ItemsSource = Genres;
        }
        protected override void OnAppearing()
        {
            BoxView.Background = ColorPallet.GetBackground();
        }

        private async void Button_OnClicked_Good(object sender, EventArgs e)
        {
            if (User.GetInstance().Contains(movie)) return;
            User.GetInstance().GoodMovies.Add(movie);
            await Navigation.PopAsync();
        }

        private async void Button_OnClicked_Bad(object sender, EventArgs e)
        {
            if (User.GetInstance().Contains(movie)) return;
            User.GetInstance().BadMovies.Add(movie);
            await Navigation.PopAsync();
        }
    }
}