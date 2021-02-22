using System;
using System.Collections;
using System.Collections.Generic;
using Proiecty_MLSA.Static_Values;
using System.Linq;
using System.Threading.Tasks;
using Paket;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemePage
    {
        public ThemePage()
        {
            InitializeComponent();
            Title = "Theme Page";
            BoxView.Background = ColorPallet.GetBackground();
            Task.Run(() => ColorPallet.AnimateBackground(BoxView));
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColorPallet.ChangeColorTheme(e.CurrentSelection.FirstOrDefault() as string);
            BoxView.Background = ColorPallet.GetBackground();
        }
    }
}