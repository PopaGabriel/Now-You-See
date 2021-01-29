using Newtonsoft.Json;
using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proiecty_MLSA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage (new MainPage());
        }

        private async void enterData()
        {
            await Task.Run(() => User.getInstance());
            await Task.Run(() => Genres.getInstance());
            await Task.Run(() => ApiHelper.getInstance());
        }

        protected override void OnStart()
        {
            enterData();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
