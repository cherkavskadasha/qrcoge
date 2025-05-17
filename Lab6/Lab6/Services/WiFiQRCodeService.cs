using QRCoder;
using System.Drawing;

namespace Lab6.Services
{
    public class WiFiQRCodeService
    {
        public void GenerateWiFiQRCode(string ssid, string password, string encryption, string filePath)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string wifiString = $"WIFI:T:{encryption};S:{ssid};P:{password};;";
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(wifiString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            using (Bitmap bitmap = qrCode.GetGraphic(20))
            {
                bitmap.Save(filePath);
            }
        }
    }
}
