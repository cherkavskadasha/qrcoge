using QRCoder;
using System;

namespace Lab6.Services
{
    public class WiFiQRCodeService
    {
        public string GenerateWiFiQRCode(string ssid, string password, string encryption, string filePath)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                string wifiString = $"WIFI:T:{encryption};S:{ssid};P:{password};;";
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(wifiString, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                using (var bitmap = qrCode.GetGraphic(20))
                {
                    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating WiFi QR code: {ex.Message}");
                return null;
            }
        }
    }
}
