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
            Calculos calculadora = new Calculos();
            double ImpedanciaIntrinseca;
            double PermissividadeRelativa;
            double distancia1, distancia2;
            double comprimento1, comprimento2;
            double frequencia;
            double larguraBanda;
            double SWRmax, SWRmin;

            try
            {
                ImpedanciaCarga.parteReal = Convert.ToDouble(ImpedanciaCargaRealText.Text);
                ImpedanciaCarga.parteImaginaria = Convert.ToDouble(ImpedanciaCargaImagText.Text);
                ImpedanciaIntrinseca = Convert.ToDouble(ImpedanciaIntriText.Text);
                PermissividadeRelativa = Convert.ToDouble(PermissividadeRelativaText.Text);
                frequencia = Convert.ToDouble(FrequenciaText.Text);
                larguraBanda = Convert.ToDouble(LarguraBandaText.Text);

                distancia1 = calculadora.distance_minus(ImpedanciaCarga.parteImaginaria,ImpedanciaCarga.parteReal,ImpedanciaIntrinseca,frequencia,PermissividadeRelativa);
                distancia2 = calculadora.distance_plus(ImpedanciaCarga.parteImaginaria, ImpedanciaCarga.parteReal, ImpedanciaIntrinseca, frequencia, PermissividadeRelativa);

                comprimento1 = calculadora.length_plus(ImpedanciaCarga, ImpedanciaCarga.parteImaginaria, ImpedanciaCarga.parteReal, ImpedanciaIntrinseca, frequencia, PermissividadeRelativa);
                comprimento2 = calculadora.length_minus(ImpedanciaCarga, ImpedanciaCarga.parteImaginaria, ImpedanciaCarga.parteReal, ImpedanciaIntrinseca, frequencia, PermissividadeRelativa);

                SWRmin = calculadora.swr_max(ImpedanciaCarga, ImpedanciaIntrinseca, distancia1, comprimento1, frequencia, larguraBanda, PermissividadeRelativa);// só falta colocar o primeiro argumento dessa função
                SWRmax = calculadora.swr_min(ImpedanciaCarga, ImpedanciaIntrinseca, distancia1, comprimento1, frequencia, larguraBanda, PermissividadeRelativa);// e dessa tbm. :)

                distancia1 *= 100;
                distancia2 *= 100;

                Distancia1Text.Content= distancia1.ToString("#.##");
                Distancia2Text.Content = distancia2.ToString("#.##");

                Compimento1Text.Content = comprimento1.ToString("#.##");
                Compimento2Text.Content = comprimento2.ToString("#.##");

                SWRmaxLabel.Content = SWRmax.ToString("#.##");
                SWRminLabel.Content = SWRmax.ToString("#.##");
            }
            catch(FormatException)
            {
                MessageBox.Show("Um valor dado é invalido! Tente novamente.","Erro de formato");
            }
            catch(OverflowException)
            {
                MessageBox.Show("Um valor é grande demais ou pequeno demais! Tente novamente.");
            }
        }

        private void ImpedanciaCargaText_Copy4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ImpedanciaCargaImagText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ImpedanciaIntriText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
