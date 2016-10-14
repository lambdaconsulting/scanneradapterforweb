using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ScannerAdapter
{
    public static class ExtBitmap
    {
        public static string ToBase64String(this Bitmap bmp, ImageFormat imageFormat)
        {
            string empty = string.Empty;
            return Convert.ToBase64String((byte[])new ImageConverter().ConvertTo((object)bmp, typeof(byte[])));
        }

        public static string ToBase64ImageTag(this Bitmap bmp, ImageFormat imageFormat)
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string base64String = bmp.ToBase64String(imageFormat);
            return "data:image/" + imageFormat.ToString() + ";base64," + base64String;
        }

        public static Bitmap base64StringToBitmap(this string base64String)
        {
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(base64String));
            memoryStream.Position = 0L;
            Bitmap bitmap = (Bitmap)Image.FromStream((Stream)memoryStream);
            return bitmap;
        }
    }
}
