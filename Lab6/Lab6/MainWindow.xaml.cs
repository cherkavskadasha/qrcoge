using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Lab6.Services;

namespace Lab6
{
    public partial class MainWindow : Window
    {
        private QRCodeService qrService = new QRCodeService();
        private DatabaseService dbService = new DatabaseService();

        public MainWindow()
        {
            InitializeComponent();
            dbService.InitializeDatabase();
        }

        private void GenerateQRCode(object sender, RoutedEventArgs e)
        {
            string content = ContentTextBox.Text;
            string fileName = $"{Guid.NewGuid()}.png";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);

            try
            {
                if (content == "Enter text or URL" || string.IsNullOrWhiteSpace(content))
                {
                    MessageBox.Show("Please enter valid text or URL.", "Warning", MessageBoxButton.OK);
                    return;
                }

                if (!Directory.Exists("Resources"))
                {
                    Directory.CreateDirectory("Resources");
                }

                qrService.GenerateQRCode(content, filePath);
                dbService.SaveQRCode(content, filePath);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath, UriKind.Absolute);
                bitmap.EndInit();
                QRCodeImage.Source = bitmap;

                MessageBox.Show("QR Code generated and saved!", "Success", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK);
            }
        }

        private void ViewSavedQRCodes(object sender, RoutedEventArgs e)
        {
            var qrCodes = dbService.GetAllQRCodes();
            string result = string.Join("\n", qrCodes);
            MessageBox.Show(result, "Saved QR Codes", MessageBoxButton.OK);
        }
    }
}
