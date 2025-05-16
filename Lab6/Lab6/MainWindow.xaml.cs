using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResetVisibility();
        }

        // Метод для зміни типу QR-коду
        private void QRCodeTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedType = ((ComboBoxItem)QRCodeTypeComboBox.SelectedItem).Content.ToString();
            ResetVisibility();

            switch (selectedType)
            {
                case "Text":
                case "URL":
                    if (ContentTextBox != null)
                        ContentTextBox.Visibility = Visibility.Visible;
                    break;

                case "Wi-Fi":
                    if (SSIDTextBox != null)
                        SSIDTextBox.Visibility = Visibility.Visible;
                    if (PasswordTextBox != null)
                        PasswordTextBox.Visibility = Visibility.Visible;
                    break;
            }
        }

        // Скидання видимості
        private void ResetVisibility()
        {
            if (ContentTextBox != null)
                ContentTextBox.Visibility = Visibility.Collapsed;
            if (SSIDTextBox != null)
                SSIDTextBox.Visibility = Visibility.Collapsed;
            if (PasswordTextBox != null)
                PasswordTextBox.Visibility = Visibility.Collapsed;
        }

        private void GenerateQRCode(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("QR Code generated!", "Success", MessageBoxButton.OK);
        }

        private void ViewSavedQRCodes(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Viewing QR Code history.", "History", MessageBoxButton.OK);
        }
    }
}
