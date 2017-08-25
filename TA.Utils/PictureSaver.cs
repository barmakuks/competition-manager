using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace TA.Utils
{
    public class PictureSaver
    {
        public static ImageFormat[] Formats = { ImageFormat.Jpeg, ImageFormat.Bmp, ImageFormat.Png, ImageFormat.Gif };
        public static string Filter { get { return Localizator.Dictionary.GetString("PICTURES_FILTER"); } }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static void SavePicture(Image bmp, string filename, ImageFormat format) 
        {
            ImageCodecInfo codec = GetEncoder(format);
            EncoderParameters parameters = null;
            if (format == ImageFormat.Jpeg) 
            {
                
                parameters = new EncoderParameters();
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);
            }
            bmp.Save(filename, codec, parameters);
        }
    }
}
