using QRCoder;
using System.Drawing;

namespace Lab6.Services
{
    public class EmailQRCodeService
    {
        public void GenerateEmailQRCode(string email, string subject, string filePath)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string emailString = $"mailto:{email}?subject={subject}";
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(emailString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            using (Bitmap bitmap = qrCode.GetGraphic(20))
            {
                bitmap.Save(filePath);
            }
        }
    }
}
