using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Lab6.Services;

namespace Lab6
{
    // Інтерфейс стратегії
    public interface IQRCodeTypeStrategy
    {
        void ApplyVisibility(MainWindow window);
    }

    // Реалізації стратегій для кожного типу
    public class TextOrUrlStrategy : IQRCodeTypeStrategy
    {
        public void ApplyVisibility(MainWindow window)
        {
            window.SetVisibility(new[] { window.ContentTextBox }, Visibility.Visible);
        }
    }

    public class WifiStrategy : IQRCodeTypeStrategy
    {
        public void ApplyVisibility(MainWindow window)
        {
            window.SetVisibility(new[] { window.SSIDTextBox, window.PasswordTextBox }, Visibility.Visible);
        }
    }

    public class EmailStrategy : IQRCodeTypeStrategy
    {
        public void ApplyVisibility(MainWindow window)
        {
            window.SetVisibility(new[] { window.EmailTextBox, window.SubjectTextBox }, Visibility.Visible);
        }
    }

    public class ContactStrategy : IQRCodeTypeStrategy
    {
        public void ApplyVisibility(MainWindow window)
        {
            window.SetVisibility(new[] { window.NameTextBox, window.PhoneTextBox }, Visibility.Visible);
        }
    }

    public partial class MainWindow : Window
    {
        private readonly QRCodeService _qrService = new QRCodeService();
        private readonly DatabaseService _dbService = new DatabaseService();

        // Зберігаємо всі можливі UI елементи для швидкого приховування
        private readonly UIElement[] _allInputElements;

        public MainWindow()
        {
            InitializeComponent();

            _allInputElements = new UIElement[]
            {
                ContentTextBox, SSIDTextBox, PasswordTextBox,
                EmailTextBox, SubjectTextBox,
                NameTextBox, PhoneTextBox
            };
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Tag == null)
            {
                textBox.Tag = textBox.Text;
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag?.ToString();
                textBox.Tag = null;
            }
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.FocusedElement is TextBox focusedTextBox && !focusedTextBox.IsMouseOver)
            {
                Keyboard.ClearFocus();
                e.Handled = true;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _dbService.InitializeDatabase();
            ResetVisibility();

            if (QRCodeTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var strategy = GetStrategyByType(selectedItem.Content.ToString());
                strategy?.ApplyVisibility(this);
            }
        }

        private void GenerateQRCode(object sender, RoutedEventArgs e)
        {
            if (ContentTextBox == null)
            {
                MessageBox.Show("Помилка: Поле Content не ініціалізовано.", "Помилка");
                return;
            }

            string content = ContentTextBox.Text.Trim();
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Заповніть поле Content");
                return;
            }

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
            Directory.CreateDirectory(folderPath);

            string fileName = $"{Guid.NewGuid()}.png";
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                _qrService.GenerateQRCode(content, filePath);
                _dbService.SaveQRCode(content, filePath);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                QRCodeImage.Source = bitmap;

                MessageBox.Show("QR-код згенеровано і збережено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
            }
        }

        private void ViewSavedQRCodes(object sender, RoutedEventArgs e)
        {
            List<string> list = _dbService.GetAllQRCodes();
            MessageBox.Show(list.Count == 0
                                ? "Історія порожня"
                                : string.Join(Environment.NewLine, list),
                            "History");
        }

        private void ClearHistory(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Очистити всі записи?", "Confirm",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _dbService.ClearAllQRCodes();
                MessageBox.Show("Історію очищено");
            }
        }

        private void QRCodeTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetVisibility();

            if (QRCodeTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var strategy = GetStrategyByType(selectedItem.Content.ToString());
                strategy?.ApplyVisibility(this);
            }
        }

        private IQRCodeTypeStrategy GetStrategyByType(string type) => type switch
        {
            "Text" or "URL" => new TextOrUrlStrategy(),
            "Wi-Fi" => new WifiStrategy(),
            "Email" => new EmailStrategy(),
            "Contact" => new ContactStrategy(),
            _ => null
        };

        private void ResetVisibility()
        {
            SetVisibility(_allInputElements, Visibility.Collapsed);
        }

        // Метод, щоб задавати видимість відразу для кількох елементів
        public void SetVisibility(UIElement[] elements, Visibility visibility)
        {
            foreach (var element in elements)
            {
                if (element != null)
                    element.Visibility = visibility;
            }
        }

        // Альтернативний метод для одиночного елемента (можна залишити приватним, якщо не хочеш робити публічним)
        private void SafeSetVisibility(UIElement element, Visibility visibility)
        {
            if (element != null)
            {
                element.Visibility = visibility;
            }
        }
    }
}
