using System.Drawing;

namespace Proiecty_MLSA.Static_Values
{
    public static class ColorPallet
    {
        public static string[] ListThemes = new string[] {"Green", "Red", "Girly", "Default"};
        public static Color BackgroundMain { get; set; }
        public static Color BackgroundCollectionItems { get; set; }
        public static Color BackgroundButton { get; set; }
        public static Color BackgroundNavigationBar { get; set; }
        public static Color BackgroundInfo { get; set; }
        public static Color TextColorInfo { get; set; }
        public static Color RefreshColor { get; set; }

        public static void ChangeColorTheme(string type)
        {
            if (type.CompareTo("Red") == 0)
            {
                BackgroundMain = Color.FromArgb(55, 6, 23);
                BackgroundCollectionItems = Color.FromArgb(230, 57, 70);
                BackgroundButton = Color.FromArgb(255, 166, 193);
                BackgroundNavigationBar = Color.FromArgb(239, 71, 111);
                TextColorInfo = Color.FromArgb(17, 138, 178);
                BackgroundInfo = Color.FromArgb(243, 114, 44);
                RefreshColor = Color.FromArgb(0, 18, 51);
            } else if (type.CompareTo("Green") == 0)
            {
                BackgroundMain = Color.FromArgb(0, 18, 51);
                BackgroundCollectionItems = Color.LightBlue;
                BackgroundButton = Color.FromArgb(5, 102, 141);
                BackgroundNavigationBar = Color.FromArgb(0, 175, 185);
                TextColorInfo = Color.FromArgb(254, 228, 63);
                BackgroundInfo = Color.ForestGreen;
                RefreshColor = Color.HotPink;
            } else if (type.CompareTo("Girly") == 0)
            {
                BackgroundMain = Color.FromArgb(0, 18, 51);
                BackgroundCollectionItems = Color.FromArgb(0, 18, 51);
                BackgroundButton = Color.FromArgb(0, 18, 51);
                BackgroundNavigationBar = Color.FromArgb(0, 18, 51);
                TextColorInfo = Color.FromArgb(0, 18, 51);
                BackgroundInfo = Color.FromArgb(0, 18, 51);
                RefreshColor = Color.FromArgb(0, 18, 51);
            } else
            {
                BackgroundMain = Color.FromArgb(0, 18, 51);
                BackgroundCollectionItems = Color.FromArgb(0, 18, 51);
                BackgroundButton = Color.FromArgb(0, 18, 51);
                BackgroundNavigationBar = Color.FromArgb(0, 18, 51);
                TextColorInfo = Color.FromArgb(0, 18, 51);
                BackgroundInfo = Color.FromArgb(0, 18, 51);
                RefreshColor = Color.FromArgb(0, 18, 51);
            }
        }

    }
}
