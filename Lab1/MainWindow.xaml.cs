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

namespace Lab1
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NumeroComplexo ImpedanciaCarga = new NumeroComplexo(0,0);
            double ImpedanciaIntrinseca;

            try
            {
                ImpedanciaCarga.parteReal = Convert.ToDouble(ImpedanciaCargaRealText.Text);
                ImpedanciaCarga.parteImaginaria = Convert.ToDouble(ImpedanciaCargaImagText.Text);
                ImpedanciaIntrinseca = Convert.ToDouble(ImpedanciaIntriText.Text);

            }
            catch(FormatException)
            {
                MessageBox.Show("Um valor de impedância dado é invalido! Tente novamente.","Erro de formato");
            }
            catch(OverflowException)
            {
                MessageBox.Show("Um valor de impedância é grande demais ou pequeno demais! Tente novamente.");
            }
        }

        private void ImpedanciaCargaText_Copy4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
