using Proiecty_MLSA.Static_Values;
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
    public partial class ThemePage : ContentPage
    {
        public ThemePage()
        {
            InitializeComponent();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Factory.StartNew(() => ColorPallet.ChangeColorTheme(e.CurrentSelection.FirstOrDefault() as string));
        }
    }
}