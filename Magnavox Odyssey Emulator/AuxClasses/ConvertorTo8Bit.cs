using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace Magnavox_Odyssey_Emulator
{
    public class ConvertorTo8Bit
    {


        public static Bitmap ConvertTo8bppFormat(Bitmap image)
        {

            // Create new image with 8BPP format
            Bitmap destImage = new Bitmap(
                image.Width,
                image.Height,
                PixelFormat.Format8bppIndexed
                );

            // Lock bitmap in memory
            BitmapData bitmapData = destImage.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                destImage.PixelFormat
                );

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    // Get source color
                    Color color = image.GetPixel(i, j);

                    // Get index of similar color 
                    byte index = GetSimilarColor(destImage.Palette, color);

                    WriteBitmapData(i, j, index, bitmapData, 8);
                }
            }

            destImage.UnlockBits(bitmapData);

            return destImage;
        }

        /// <summary>
        /// Returns Similar color 
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private static byte GetSimilarColor(ColorPalette palette, Color color)
        {

            byte minDiff = byte.MaxValue;
            byte index = 0;

            for (int i = 0; i < palette.Entries.Length - 1; i++)
            {

                byte currentDiff = GetMaxDiff(color, palette.Entries[i]);

                if (currentDiff < minDiff)
                {
                    minDiff = currentDiff;
                    index = (byte)i;
                }
            }

            return index;
        }

        /// <summary>
        /// Return similar color
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static byte GetMaxDiff(Color a, Color b)
        {

            byte bDiff = System.Convert.ToByte(
                Math.Abs((short)(a.B - b.B)));

            byte gDiff = System.Convert.ToByte(
                Math.Abs((short)(a.G - b.G)));

            byte rDiff = System.Convert.ToByte(
                Math.Abs((short)(a.R - b.R)));

            return Math.Max(rDiff, Math.Max(bDiff, gDiff));
        }

        /// <summary>
        /// Writing to bitmap
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="index"></param>
        /// <param name="data"></param>
        /// <param name="pixelSize"></param> 
        private static void WriteBitmapData(
            int i,
            int j,
            byte index,
            BitmapData data,
            int pixelSize)
        {

            double entry = pixelSize / 8;

            // Get unmanaged address of needed byte
            IntPtr realByteAddr = new IntPtr(System.Convert.ToInt32(
                                  data.Scan0.ToInt32() +
                                  (j * data.Stride) + i * entry));

            // Create array with data to copy
            byte[] dataToCopy = new byte[] { index };

            // Perfrom copy
            Marshal.Copy(dataToCopy, 0, realByteAddr,
                          dataToCopy.Length);
        }
    }
}
