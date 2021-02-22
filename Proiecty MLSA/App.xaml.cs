using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using System.Threading.Tasks;
using Xamarin.Forms;
using Lottie.Forms;

namespace Proiecty_MLSA
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Brush_Experimental" });
            ColorPallet.ChangeColorTheme("Girly");
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        private async void enterData()
        {
            await Task.Run(User.GetInstance);
            await Task.Run(Genres.GetInstance);
            await Task.Run(ApiHelper.getInstance);
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
