using System;
using System.Threading.Tasks;
using Proiecty_MLSA.Themes;
using Xamarin.Forms;

namespace Proiecty_MLSA.Static_Values
{
    public static class ColorPallet
    {
        public static readonly string[] ListThemes = { "Default Theme", "Red Theme","Girly Theme", "Space Theme", "HighContrast Theme", "Nature Theme", "Summer Theme" };
        public static Brush GetBackground()
        {
            var background = new LinearGradientBrush
            {
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
        public static async void AnimateBackground(BoxView boxViewBackground)
        {
            void Forward(double input) => boxViewBackground.AnchorY = (float) input;
            void Backward(double input) => boxViewBackground.AnchorY = (float) input;

            while (true)
            {
                boxViewBackground.Animate(name: "forward", callback: Forward, start: 0, end: 1, length: 4000, easing: Easing.SinIn);
                await Task.Delay(6000);
                boxViewBackground.Animate(name: "backward", callback: Backward, start: 1, end: 0, length: 4000, easing: Easing.SinIn);
                await Task.Delay(6000);
            }
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
                    case "Space Theme":
                        {
                            mergedDictionaries.Add(new Space());
                            break;
                        }
                    case "HighContrast Theme":
                        {
                            mergedDictionaries.Add(new HighContrast());
                            break;
                        }
                    case "Nature Theme":
                        {
                        mergedDictionaries.Add(new Nature());
                        break;
                        }
                    case "Summer Theme":
                    {
                        mergedDictionaries.Add(new Summer());
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
