using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Lab6.Services
{
    public class ContactQRCodeService
    {
        public void GenerateContactQRCode(string name, string phone, string filePath)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                string contactString = $"MECARD:N:{name};TEL:{phone};;";
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(contactString, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                using (Bitmap qrBitmap = qrCode.GetGraphic(20))
                {
                    qrBitmap.Save(filePath, ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating Contact QR code: {ex.Message}");
            }
        }
    }
}
