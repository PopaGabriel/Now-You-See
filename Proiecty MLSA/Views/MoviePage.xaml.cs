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
            foreach (Genre genre in genres)
            {
                Console.Out.WriteLine(genre + " De ce");
            }

            BackgroundColor = ColorPallet.BackgroundMain;
            FrameStack.BackgroundColor = ColorPallet.BackgroundMain;

            NameLabel.TextColor = ColorPallet.TextColorInfo;
            MarkLabel.TextColor = ColorPallet.TextColorInfo;
            OverviewLabel.TextColor = ColorPallet.TextColorInfo;
            YourMarkLabel.TextColor = ColorPallet.TextColorInfo;

            NameLabel.BackgroundColor = ColorPallet.BackgroundInfo;
            MarkLabel.BackgroundColor = ColorPallet.BackgroundInfo;
            OverviewLabel.BackgroundColor = ColorPallet.BackgroundInfo;
            YourMarkLabel.BackgroundColor = ColorPallet.BackgroundInfo;
            Carousel.BackgroundColor = ColorPallet.BackgroundInfo;
        }
        public void AddToUserList(object sender, EventArgs e)
        {

        }
        public void RemoveFromUserList(object sender, EventArgs e)
        {

        }
    }
}