using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Lab6.Services
{
    public class QRCodeService
    {
        public string GenerateQRCode(string content, string filePath)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                using (Bitmap qrBitmap = qrCode.GetGraphic(20))
                {
                    qrBitmap.Save(filePath, ImageFormat.Png);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error generating QR code: {ex.Message}");
            }
        }
    }
}
