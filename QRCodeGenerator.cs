using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.Common;

namespace QRCodeCore
{
    public static class QRCodeGenerator
    {
        public static void GenerateQRCode(this Stream file, string content)
        {
            try
            {
                var qrCodeWriter = new BarcodeWriterPixelData
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions
                    {
                        Margin = 0,
                        Height = 250,
                        Width = 250
                    }
                };
                var pixelData = qrCodeWriter.Write(content);

                using (Image<Rgba32> image = new Image<Rgba32>(pixelData.Width, pixelData.Height))
                {
                    var ms = new MemoryStream();                    
                    byte[] pixels = pixelData.Pixels;

                    int index = 0;
                    for (int i = 0; i < pixelData.Height; i++)
                    {
                        for (int j = 0; j < pixelData.Width; j++)
                        {
                            image[i, j] = pixels[index*4] == byte.MinValue ? Rgba32.ParseHex("#000000"): Rgba32.ParseHex("#FFFFFF");
                            index += 1;
                        }
                    }
                    image.SaveAsPng(file);
                }
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}