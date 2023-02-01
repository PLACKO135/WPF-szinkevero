using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Szinkeveres()
        {
            teglalap.Fill = new SolidColorBrush(
                Color.FromRgb(
                    Convert.ToByte(piros.Value), Convert.ToByte(zöld.Value), Convert.ToByte(kek.Value)
                    )
                );
        }
        private void piros_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();
        }

        private void zöld_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();
        }

        private void kek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Szinkeveres();
        }

        private void rogzit_Click(object sender, RoutedEventArgs e)
        {
            String szinadatok = $"{Convert.ToByte(piros.Value)};{Convert.ToByte(zöld.Value)};{Convert.ToByte(kek.Value)}";
            if (!szinek.Items.Contains(szinadatok))
            {
                szinek.Items.Add(szinadatok);
            }
            else 
            {
                MessageBox.Show("Ez a szín már rögzítve van");
            }
        }

        private void torol_Click(object sender, RoutedEventArgs e)
        {
            if (szinek.SelectedIndex>=0)
            { 
                szinek.Items.RemoveAt(szinek.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a listában");
            }
        }

        private void urit_Click(object sender, RoutedEventArgs e)
        {
            szinek.Items.Clear();
        }

        private void szinek_Selected(object sender, RoutedEventArgs e)
        {
            string[] tagok = szinek.SelectedItem.ToString().Split(';');
            piros.Value = Convert.ToByte(tagok[0]);
            zöld.Value = Convert.ToByte(tagok[1]);
            kek.Value = Convert.ToByte(tagok[2]);

            teglalap.Fill = new SolidColorBrush(
               Color.FromRgb(
                   Convert.ToByte(piros.Value), Convert.ToByte(zöld.Value), Convert.ToByte(kek.Value)
                   )
               );
        }
    }
}
