using Proiecty_MLSA.Themes;
using Xamarin.Forms;

namespace Proiecty_MLSA.Static_Values
{
    public static class ColorPallet
    {
        public static string[] ListThemes = new string[] { "DefaultTheme", "RedTheme" };

        public static void ChangeColorTheme(string v)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                switch (v)
                {
                    case "Red":
                        {
                            mergedDictionaries.Add(new RedTheme());
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
