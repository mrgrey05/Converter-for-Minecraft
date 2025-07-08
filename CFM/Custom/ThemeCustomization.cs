using System;
using System.Drawing;

namespace CFM.Custom
{
    public static class ThemeCustomization
    {
        public static Color ColorDarker(Color color)
        {
            int red = color.R;
            int green = color.G;
            int blue = color.B;
            int alpha = color.A;

            int redChange = red - 10;
            int greenChange = green - 10;
            int blueChange = blue - 10;

            redChange = Math.Max(0, redChange);
            greenChange = Math.Max(0, greenChange);
            blueChange = Math.Max(0, blueChange);

            Color changedColor = Color.FromArgb(alpha, redChange, greenChange, blueChange);
            return changedColor;
        }
        public static Color ColorDarkerMenu(Color color)
        {
            int red = color.R;
            int green = color.G;
            int blue = color.B;
            int alpha = color.A;

            int redChange = red - 7;
            int greenChange = green - 7;
            int blueChange = blue - 7;

            redChange = Math.Max(0, redChange);
            greenChange = Math.Max(0, greenChange);
            blueChange = Math.Max(0, blueChange);

            Color changedColor = Color.FromArgb(alpha, redChange, greenChange, blueChange);
            return changedColor;
        }
        public static Color ColorDarkerBase(Color color)
        {
            int red = color.R;
            int green = color.G;
            int blue = color.B;
            int alpha = color.A;

            int redChange = red - 17;
            int greenChange = green - 17;
            int blueChange = blue - 17;

            redChange = Math.Max(0, redChange);
            greenChange = Math.Max(0, greenChange);
            blueChange = Math.Max(0, blueChange);

            Color changedColor = Color.FromArgb(alpha, redChange, greenChange, blueChange);
            return changedColor;
        }
        public static Color ColorDarkerHover(Color color)
        {
            int red = color.R;
            int green = color.G;
            int blue = color.B;
            int alpha = color.A;

            int redChange = red - 11;
            int greenChange = green - 11;
            int blueChange = blue - 11;

            redChange = Math.Max(0, redChange);
            greenChange = Math.Max(0, greenChange);
            blueChange = Math.Max(0, blueChange);

            Color changedColor = Color.FromArgb(alpha, redChange, greenChange, blueChange);
            return changedColor;
        }
        public static Color ColorDarkerClick(Color color)
        {
            int red = color.R;
            int green = color.G;
            int blue = color.B;
            int alpha = color.A;

            int redChange = red - 4;
            int greenChange = green - 4;
            int blueChange = blue - 4;

            redChange = Math.Max(0, redChange);
            greenChange = Math.Max(0, greenChange);
            blueChange = Math.Max(0, blueChange);

            Color changedColor = Color.FromArgb(alpha, redChange, greenChange, blueChange);
            return changedColor;
        }
    }
}
