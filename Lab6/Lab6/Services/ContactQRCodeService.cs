using QRCoder;
using System.Drawing;

namespace Lab6.Services
{
    public class ContactQRCodeService
    {
        public void GenerateContactQRCode(string name, string phone, string filePath)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string contactString = $"MECARD:N:{name};TEL:{phone};;";
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(contactString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            using (Bitmap bitmap = qrCode.GetGraphic(20))
            {
                bitmap.Save(filePath);
            }
        }
    }
}
