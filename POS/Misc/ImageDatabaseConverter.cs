using System.Drawing;
using System.IO;

namespace POS.Misc
{
    public static class ImageDatabaseConverter
    {
        public static byte[] ToByteArray(this System.Drawing.Image imageIn)
        {
            if (imageIn == null)
                return null;            

            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(imageIn, typeof(byte[]));
            return xByte;
        }
        public static Image ToImage(this byte[] byteArrayIn)
        {
            if (byteArrayIn == null)
                return null;

            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
