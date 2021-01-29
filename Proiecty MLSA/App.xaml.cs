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

        protected override void OnStart()
        {
            Task.Run(() => User.getInstance());
            Task.Run(()=> Genres.getInstance());
            Task.Run(() => ApiHelper.getInstance());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
