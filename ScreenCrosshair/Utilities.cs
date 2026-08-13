using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Utils
{
    public class Utilities
    {
        public static Color GetScreenPixelColor(int x, int y)
        {
            using (Bitmap bitmap = new Bitmap(1, 1))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(x, y, 0, 0, new Size(1, 1));
                return bitmap.GetPixel(0, 0);
            }
        }

        public static Color GetAverageColor(Rectangle region)
        {
            using (Bitmap bitmap = new Bitmap(region.Width, region.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(region.Location, Point.Empty, region.Size);

                    long totalR = 0;
                    long totalG = 0;
                    long totalB = 0;

                    int pixelCount = bitmap.Width * bitmap.Height;

                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            Color color = bitmap.GetPixel(x, y);

                            totalR += color.R;
                            totalG += color.G;
                            totalB += color.B;
                        }
                    }

                    return Color.FromArgb(
                        (int)(totalR / pixelCount),
                        (int)(totalG / pixelCount),
                        (int)(totalB / pixelCount));
                }
            }
        }

       
        
    }
}
