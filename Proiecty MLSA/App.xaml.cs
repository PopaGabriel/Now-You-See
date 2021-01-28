using Proiecty_MLSA.Static_Values;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage (new MainPage());
        }

        protected override void OnStart()
        {
            var t1 = Task.Factory.StartNew(() => Genres.getInstance());
            var t2 = Task.Factory.StartNew(() => ApiHelper.getInstance());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
