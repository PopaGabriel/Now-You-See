using Newtonsoft.Json;
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
            //MainPage = new NavigationPage (new MainPage());
        }

        protected override void OnStart()
        {
            string route = "D:\\fileTest.txt";
            FileStream fs = new FileStream(route, FileMode.Create);
            
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
