using Proiecty_MLSA.Themes;
using Xamarin.Forms;

namespace Proiecty_MLSA.Static_Values
{
    public static class ColorPallet
    {
        public static readonly string[] ListThemes = { "Default Theme", "Red Theme","Girly Theme" };
        public static Brush GetBackground()
        {
            var background = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1),
                GradientStops = new GradientStopCollection
                {
                    new GradientStop
                    {
                        Color = (Color) Application.Current.Resources["BackgroundNavigationBar"]
                        , Offset = 0.1f
                    },
                    new GradientStop
                    {
                        Color = (Color) Application.Current.Resources["BackgroundButton"],
                        Offset = 0.5f
                    },
                    new GradientStop {
                        Color = (Color) Application.Current.Resources["BackgroundInfo"],
                        Offset = 0.9f
                    }
                }
            };
            return background;
        }
        public static void ChangeColorTheme(string v)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                switch (v)
                {
                    case "Red Theme":
                        {
                            mergedDictionaries.Add(new RedTheme());
                            break;
                        }
                    case "Girly Theme":
                        {
                            mergedDictionaries.Add(new Girly());
                            break;
                        }
                    default:
                        {
                            mergedDictionaries.Add(new LightBlueTheme());
                            break;
                        }

                }
            }
        }
    }
}
