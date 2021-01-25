using System;
using System.IO;
using System.Drawing;

namespace utils
{
	class Img
	{
		public static byte[] ImageToByteArray(Image imageIn)
		{
			System.Drawing.ImageConverter imgCon = new System.Drawing.ImageConverter();
            return (byte[])imgCon.ConvertTo(imageIn, typeof(byte[]));
		}
		
		public static Image resizeImage(Image imgToResize, Size size)
    	{
      		 return (Image)(new Bitmap(imgToResize, size));
    	}
	}
}