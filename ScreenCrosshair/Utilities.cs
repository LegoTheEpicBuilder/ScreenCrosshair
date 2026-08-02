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

       
        public static Color GetAverageColorRaw(Rectangle region)
        {
            using (Bitmap bitmap = new Bitmap(region.Width, region.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(region.Location, Point.Empty, region.Size);
                }

                BitmapData data = bitmap.LockBits(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format24bppRgb
                );

                try
                {
                    long totalR = 0;
                    long totalG = 0;
                    long totalB = 0;

                    int bytesPerPixel = 3;
                    int stride = data.Stride;

                    byte[] pixels = new byte[stride * bitmap.Height];

                    Marshal.Copy(
                        data.Scan0,
                        pixels,
                        0,
                        pixels.Length
                    );

                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        int rowStart = y * stride;

                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            int pixelStart = rowStart + x * bytesPerPixel;

                            // Format24bppRgb stores pixels as BGR, not RGB
                            totalB += pixels[pixelStart];
                            totalG += pixels[pixelStart + 1];
                            totalR += pixels[pixelStart + 2];
                        }
                    }

                    int pixelCount = bitmap.Width * bitmap.Height;

                    return Color.FromArgb(
                        (int)(totalR / pixelCount),
                        (int)(totalG / pixelCount),
                        (int)(totalB / pixelCount)
                    );
                }
                finally
                {
                    bitmap.UnlockBits(data);
                }
            }
        }

        public static Color ReverseColor(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        public static Color GetReverseBlackOrWhite(Color color)
        {
            double brightness =
            0.299 * color.R +
            0.587 * color.G +
            0.114 * color.B;

            Color bestColor = brightness > 128
            ? Color.Black
            : Color.White;

            return bestColor;
        }
    }
}
