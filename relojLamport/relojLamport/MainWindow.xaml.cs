using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;
using relojLamport.Recursos;
using System.Text.RegularExpressions;

namespace relojLamport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> listsDestinosP1;
        private List<string> listsDestinosP2;
        private List<string> listsDestinosP3;

        private ObservableCollection<Mensaje> ColaEsperaP1 = new ObservableCollection<Mensaje>();
        private ObservableCollection<Mensaje> ColaEsperaP2 = new ObservableCollection<Mensaje>();
        private ObservableCollection<Mensaje> ColaEsperaP3 = new ObservableCollection<Mensaje>();

        private Dictionary<int, List<Mensaje>> DiccionarioEspera = new Dictionary<int, List<Mensaje>>();
        private List<HiloProcesador> listaProcesos = new List<HiloProcesador>();

        public MainWindow()
        {
            InitializeComponent();
            listsDestinosP1 = new List<string>
            {
                "P2",
                "P3",
            };

            procesoDestinoP1.ItemsSource = listsDestinosP1;

            listsDestinosP2 = new List<string>
            {
                "P1",
                "P3",
            };

            procesoDestinoP2.ItemsSource = listsDestinosP2;

            listsDestinosP3 = new List<string>
            {
                "P1",
                "P2",
            };

            procesoDestinoP3.ItemsSource = listsDestinosP3;
        }

        public ObservableCollection<Mensaje> MostrarMensajesProceso1
        {
            get { return ColaEsperaP1; }
        }

        public ObservableCollection<Mensaje> MostrarMensajesProceso2
        {
            get { return ColaEsperaP2; }
        }

        public ObservableCollection<Mensaje> MostrarMensajesProceso3
        {
            get { return ColaEsperaP3; }
        }
        

        private void TextBlock_GotTouchCapture(object sender, System.Windows.Input.TouchEventArgs e)
        {

        }

        private void botonEnviar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void botonEnviarP2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void botonEnviarP3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EsNumero(object sender, TextCompositionEventArgs e)
        {
            if (!CalcularEsNumero(e.Text))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public static bool CalcularEsNumero(string number)
        {
            Regex numberRegularExpression = new Regex(@"(\d{1,4})$");

            return numberRegularExpression.IsMatch(number);
        }
    }
}
