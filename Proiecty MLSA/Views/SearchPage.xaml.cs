using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Paket;
using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using Proiecty_MLSA.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPageXama
    {
        public ObservableCollection<SavedMovie> SearchedMovies { set; get; }

        public SearchPageXama(ObservableCollection<SavedMovie> listOfSavedMovies)
        {
            InitializeComponent();
            BoxView.Background = ColorPallet.GetBackground();
            Task.Run(() => ColorPallet.AnimateBackground(BoxView));
            CollectionViewSearchPage.ItemsSource = listOfSavedMovies;
            BindingContext = this;
        }

        public SearchPageXama()
        {
            InitializeComponent();
            BoxView.Background = ColorPallet.GetBackground();
            Task.Run(() => ColorPallet.AnimateBackground(BoxView));
        }

        private async void NavigationBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchText = NavigationBar.Text.ToLower().Replace(" ","%20");
            var apiHelper = ApiHelper.getInstance();

            SearchedMovies = await apiHelper.SearchMovies(searchText);
            CollectionViewSearchPage.ItemsSource = SearchedMovies;
            BindingContext = this;
        }

        private async void CollectionViewMainPage_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is SavedMovie selectedMovie))
                return;

            if (User.GetInstance().Contains(selectedMovie)) await Navigation.PushAsync(new RatedMovie(selectedMovie));
            else await Navigation.PushAsync(new MoviePage(selectedMovie));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}