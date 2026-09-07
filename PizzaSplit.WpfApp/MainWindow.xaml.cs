using System;
using System.Globalization;
using System.Windows;
using PizzaSplit.Core;

namespace PizzaSplit.WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            TxtError.Text = string.Empty;
            TxtShare.Text = string.Empty;

            var culture = new CultureInfo("et-EE");
            string totalInput = TxtTotal.Text.Trim().Replace('.', ',');

            if (!decimal.TryParse(totalInput, NumberStyles.Number, culture, out decimal total) || total <= 0 || total > 10000)
            {
                TxtError.Text = "Viga: sisesta korrektne summa vahemikus 0,01 kuni 10 000 €.";
                return;
            }

            if (!int.TryParse(TxtPeople.Text.Trim(), out int people) || people < 1 || people > 20)
            {
                TxtError.Text = "Viga: sööjate arv peab olema täisarv vahemikus 1 kuni 20.";
                return;
            }

            bool addTip = ChkTip.IsChecked ?? false;

            try
            {
                decimal share = PizzaCalculator.CalculateShare(total, people, addTip);
                TxtShare.Text = share.ToString("F2", culture);
            }
            catch (Exception ex)
            {
                TxtError.Text = ex.Message;
            }
        }
    }
}