using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZXing.QrCode;

//Special thanks to saksitu and his code which was levered in this method
//https://github.com/saksitsu/-NetCore-QRCodeGenrate.git

namespace QrCodeApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncodeController : ControllerBase
    {
        // GET api/encode
        [HttpGet]
        public ActionResult<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return "Error: Usage- /api/encode/text=TextToEncode&size=SizeOfQrCode";
        }

        // GET api/encode/SomeReallyLongText
        [HttpGet("text={text}&size={size}")]
        public ActionResult<FileStreamResult> Get(string text, int size)
        {
            return QrEncode(text, size);
        }

        // POST api/encode
        //[HttpPost]
        //public ActionResult<Bitmap> Post([FromBody] string value)
        //{
        //    return QrEncode(value);
        //}

        private FileResult QrEncode(string value, int size=250, Bitmap bgImage=null )
        {
            //Create QRCode
            var qrWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions { Height = Convert.ToInt32(size), Width = Convert.ToInt32(size), Margin = 0 }
            };

            var pixelData = qrWriter.Write(value);

            if (bgImage !=null)
            {
                //TODO: Support Background watermarks
                //icon thaiqrcode
                //##########################
                //Bitmap overlayImage = bgImage;//IconQR

            }

            // creating a bitmap from the raw pixel data; if only black and white colors are used it makes no difference
            // that the pixel data ist BGRA oriented and the bitmap is initialized with RGB
            // the System.Drawing.Bitmap class is provided by the CoreCompat.System.Drawing package
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            using (var ms = new MemoryStream())
            {
                // lock the data area for fast access
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height),
                   System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                       pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }

                Bitmap QRBBitmap;
                Bitmap QRBImage = bitmap;
                QRBBitmap = QRBImage;
                ms.Flush();
                var graphics = Graphics.FromImage(QRBImage);

                //graphics.CompositingMode = CompositingMode.SourceOver;
                //int overlaywidth = overlayImage.Width;
                //int overlayheight = overlayImage.Height;
                //graphics.DrawImage(overlayImage, ((Convert.ToInt32(size) - 40) / 2), ((Convert.ToInt32(size) - 40) / 2), 40, 40);
                graphics.Save();
                // save to stream as PNG
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                return File(ms.ToArray(), "image/png");
                //return new FileContentResult(ms.ToArray(), "image/png")
                //{
                //    FileDownloadName = "QRCode.png"
                //};
            }

                
        }
    }
}
