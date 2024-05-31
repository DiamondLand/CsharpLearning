using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BitcoinTradingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text;
            string[] inputLines = inputText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (inputLines.Length < 2)
            {
                MessageBox.Show("Введите как минимум два значения курса биткоина.");
                return;
            }

            List<int> bitcoinPrices = new List<int>();
            foreach (string line in inputLines)
            {
                if (int.TryParse(line, out int price))
                {
                    bitcoinPrices.Add(price);
                }
                else
                {
                    MessageBox.Show("Неверный формат входных данных.");
                    return;
                }
            }

            Tuple<int, int, int> result = CalculateMaxProfit(bitcoinPrices);

            if (result.Item1 > 0)
            {
                OutputTextBox.Text = $"{result.Item1} {result.Item2 - 1} {result.Item3 - 1}";
            }
            else
            {
                OutputTextBox.Text = "Невозможно получить выручку.";
            }
        }
        private Tuple<int, int, int> CalculateMaxProfit(List<int> prices)
        {
            if (prices == null || prices.Count < 2)
            {
                return new Tuple<int, int, int>(0, 0, 0);
            }

            int maxProfit = 0;
            int buyDay = 0;
            int sellDay = 0;
            int minPrice = prices[0];

            for (int i = 1; i < prices.Count; i++)
            {
                int currentProfit = prices[i] - minPrice;

                if (currentProfit > maxProfit)
                {
                    maxProfit = currentProfit;
                    buyDay = prices.IndexOf(minPrice) + 1;
                    sellDay = i + 1;
                }

                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
            }

            return new Tuple<int, int, int>(maxProfit, buyDay, sellDay);
        }

    }
}
