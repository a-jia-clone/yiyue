using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using ThoughtWorks.QRCode.Codec;

namespace YiYue.handlers
{
    /// <summary>
    /// Summary description for qrcode
    /// </summary>
    public class qrcode : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/gif";

            string enCodeString = context.Server.UrlDecode(context.Request.QueryString["code"]);
            QRCodeEncoder codeEncoder = new QRCodeEncoder();
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //设置二维码的规模，默认4
            qrCodeEncoder.QRCodeScale = 4;
            //设置二维码的版本，默认7
            qrCodeEncoder.QRCodeVersion = 7;
            //设置错误校验级别，默认中等
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //生成二维码图片
            Bitmap image = codeEncoder.Encode(enCodeString, Encoding.UTF8);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}