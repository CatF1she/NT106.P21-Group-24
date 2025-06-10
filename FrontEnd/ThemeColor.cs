using System.Collections.Generic;
using System.Drawing;

namespace FrontEnd
{
    public static class ThemeColor
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }

        // Màu cố định cho từng chức năng
        public static readonly Dictionary<string, string> FunctionColorMap = new()
        {
            { "GameLobby", "#3F51B5" },
            { "Leaderboard", "#009688" },
            { "Profile", "#F57F22" },
            { "Settings", "#607D8B" },
            { "Friends", "#E4144A" },
            { "Notification", "#9C27B0" }
        };

        public static Color GetFunctionColor(string functionName)
        {
            if (FunctionColorMap.TryGetValue(functionName, out var hex))
                return ColorTranslator.FromHtml(hex);
            return Color.Gray; // fallback
        }

        public static Color ChangeColorBrightness(Color color, double correctionfactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctionfactor < 0)
            {
                correctionfactor = 1 + correctionfactor;
                red *= correctionfactor;
                green *= correctionfactor;
                blue *= correctionfactor;
            }
            else
            {
                red = (255 - red) * correctionfactor + red;
                green = (255 - green) * correctionfactor + green;
                blue = (255 - blue) * correctionfactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
