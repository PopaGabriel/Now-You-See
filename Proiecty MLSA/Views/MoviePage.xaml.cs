using Proiecty_MLSA.Classes;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        public MoviePage(Saved_Movie Movielet)
        {
            InitializeComponent();
            MovieStack.BindingContext = Movielet;
            BindingContext = this;
        }
        public void AddToUserList(object sender, EventArgs e)
        {

        }
        public void RemoveFromUserList(object sender, EventArgs e)
        {

        }
    }
}