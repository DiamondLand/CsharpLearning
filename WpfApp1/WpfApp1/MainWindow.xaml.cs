using System;
using System.Linq;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputSequence = InputTextBox.Text;
            string result = FindMinimalNumber(inputSequence);
            ResultLabel.Content = result;
        }

        private string FindMinimalNumber(string inputStr)
        {
            var allDigits = "123456789".ToHashSet();
            var inputDigits = inputStr.Where(char.IsDigit).ToHashSet();
            var missingDigits = allDigits.Except(inputDigits);

            return missingDigits.Any() ? string.Join("", missingDigits.OrderBy(c => c)) : "0";
        }
    }
}
