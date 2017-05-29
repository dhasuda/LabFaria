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

                distancia1 = calculadora.distance_minus(ImpedanciaCarga.parteImaginaria,ImpedanciaCarga.parteReal,ImpedanciaIntrinseca,frequencia,PermissividadeRelativa)*100;
                distancia2 = calculadora.distance_plus(ImpedanciaCarga.parteImaginaria, ImpedanciaCarga.parteReal, ImpedanciaIntrinseca, frequencia, PermissividadeRelativa) *100;

                comprimento1 = calculadora.length(ImpedanciaCarga, ImpedanciaIntrinseca, frequencia, PermissividadeRelativa);
                comprimento2 = comprimento1;

                SWRmin = calculadora.swr(,ImpedanciaIntrinseca);// só falta colocar o primeiro argumento dessa função
                SWRmax = calculadora.swr(,ImpedanciaIntrinseca);// e dessa tbm. :)



                Distancia1Text.Content= Convert.ToString(distancia1);
                Distancia2Text.Content = Convert.ToString(distancia2);

                Compimento1Text.Content = Convert.ToString(comprimento1);
                Compimento2Text.Content = Convert.ToString(comprimento2);

                SWRmaxText.Content = Convert.ToString(SWRmax);
                SWRminText.Content = Convert.ToString(SWRmin);
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

        private void ImpedanciaCargaImagText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
