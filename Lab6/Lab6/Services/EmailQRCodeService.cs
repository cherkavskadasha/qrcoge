using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Lab6.Services
{
    public class EmailQRCodeService
    {
        public void GenerateEmailQRCode(string email, string subject, string filePath)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                string emailString = $"mailto:{email}?subject={Uri.EscapeDataString(subject)}";
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(emailString, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                using (Bitmap qrBitmap = qrCode.GetGraphic(20))
                {
                    qrBitmap.Save(filePath, ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating Email QR code: {ex.Message}");
            }
        }
    }
}
