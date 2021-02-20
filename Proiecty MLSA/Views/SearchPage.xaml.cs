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
        public ObservableCollection<Saved_Movie> SearchedMovies { set; get; }
        public SearchPageXama(string name)
        {
            Background = ColorPallet.GetBackground();
            InitializeComponent();
        }

        private async void NavigationBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchText = NavigationBar.Text.ToLower().Replace(" ","%20");
            var apiHelper = ApiHelper.getInstance();

            SearchedMovies = await apiHelper.SearchMovies(searchText);
            CollectionViewSearchPage.ItemsSource = SearchedMovies;
            BindingContext = this;

            Console.Out.WriteLine(searchText);
        }

        private async void CollectionViewMainPage_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is Saved_Movie selectedMovie))
                return;

            await Navigation.PushAsync(new MoviePage(selectedMovie));

            ((CollectionView)sender).SelectedItem = null;

        }
    }
}