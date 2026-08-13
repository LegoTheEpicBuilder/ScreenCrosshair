using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCrosshair
{
    public class RegionReader
    {
        public Rectangle Region { get; set; }
        public Rectangle ExcludingRegion { get; set; } = Rectangle.Empty;

        public RegionReader() 
        { 
            
        }

        public Color GetAverageColorRaw()
        {
            using (Bitmap bitmap = new Bitmap(Region.Width, Region.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Region.Location, Point.Empty, Region.Size);
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

                    int includedPixelCount = 0;

                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        int rowStart = y * stride;

                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            //the pixel is not taken into account when it is part of the excluded zone
                            if (ExcludingRegion.Contains(x + Region.X, y + Region.Y)) { continue; }
                            
                            int pixelStart = rowStart + x * bytesPerPixel;

                            //Format24bppRgb stores pixels as BGR, not RGB apparently
                            totalB += pixels[pixelStart];
                            totalG += pixels[pixelStart + 1];
                            totalR += pixels[pixelStart + 2];

                            includedPixelCount++;
                        }
                    }

                    return Color.FromArgb(
                        (int)(totalR / includedPixelCount),
                        (int)(totalG / includedPixelCount),
                        (int)(totalB / includedPixelCount)
                    );
                }
                finally
                {
                    bitmap.UnlockBits(data);
                }
            }
        }

        public Color GetMostReadableColorOverRegion()
        {
            Color color = GetAverageColorRaw();

            //these magic numbers correspond to how much percent each channel actually matters for brightness
            double brightness =
            0.299 * color.R +
            0.587 * color.G +
            0.114 * color.B;

            Debug.WriteLine($"color: {color}, brightness: {brightness}");

            Color bestColor = brightness > 128
            ? Color.Black
            : Color.White;

            return bestColor;
        }
    }
}
