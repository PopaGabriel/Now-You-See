using Proiecty_MLSA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        public MoviePage(Movie Movielet)
        {
            InitializeComponent();
            MovieStack.BindingContext = Movielet;
            ListViewMoviePage.ItemsSource = Movielet.Team;
            BindingContext = this;
        }
        public void AddToUserList(object sender,EventArgs e)
        {

        }
        public void RemoveFromUserList(object sender, EventArgs e)
        {

        }
    }
}