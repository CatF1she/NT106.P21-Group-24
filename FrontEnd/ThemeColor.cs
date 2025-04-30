using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public static class ThemeColor
    {
        public static List<string> ColorList = new List<string>() { "#3F51B5",
                                                                    "#009688",
                                                                    "#F57F22",
                                                                    "#607D8B",
                                                                    "#FF9800",
                                                                    "#9C27B0",
                                                                    "#2196F3",
                                                                    "#E4676C",
                                                                    "#E4144A",
                                                                    "#59788B",
                                                                    "#E01797",
                                                                    "#0E3441",
                                                                    "#008D4C",
                                                                    "#7A1D47",
                                                                    "#E4B833",
                                                                    "#FF973E",
                                                                    "#F37521",
                                                                    "#A12059",
                                                                    "#116281",
                                                                    "#88C248",
                                                                    "#364D5B",
                                                                    "#C7DC5B",
                                                                    "#0E949C",
                                                                    "#E4126E",
                                                                    "#43B76E",
                                                                    "#7BCFE9",
                                                                    "#B71C46"};
        public static Color ChangeColorBrightness(Color color, double correctionfactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            // Nếu correctionfactor < 0 --> màu tối hơn
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
