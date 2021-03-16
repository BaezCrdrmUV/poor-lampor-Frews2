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
        
        private List<HiloProcesador> listaDestinosP1;
        private List<HiloProcesador> listaDestinosP2;
        private List<HiloProcesador> listaDestinosP3;

        private ObservableCollection<HiloProcesador> listaProcesos;
        private ObservableCollection<Mensaje> historialP1;
        private ObservableCollection<Mensaje> historialP2;
        private ObservableCollection<Mensaje> historialP3;

        private Dictionary<int, List<Mensaje>> diccionarioEspera = new Dictionary<int, List<Mensaje>>();

        public MainWindow()
        {
            InitializeComponent();

            listaProcesos = new ObservableCollection<HiloProcesador>
            {
                new HiloProcesador(1),
                new HiloProcesador(2),
                new HiloProcesador(3)
            };

            diccionarioEspera.Add(1, new List<Mensaje>());
            diccionarioEspera.Add(2, new List<Mensaje>());
            diccionarioEspera.Add(3, new List<Mensaje>());

            listaDestinosP1 = new List<HiloProcesador>
            {
                listaProcesos[1],
                listaProcesos[2],
            };

            procesoDestinoP1.ItemsSource = listaDestinosP1;

            listaDestinosP2 = new List<HiloProcesador>
            {
                listaProcesos[0],
                listaProcesos[2],
            };

            procesoDestinoP2.ItemsSource = listaDestinosP2;

            listaDestinosP3 = new List<HiloProcesador>
            {
                listaProcesos[0],
                listaProcesos[1],
            };

            procesoDestinoP3.ItemsSource = listaDestinosP3;

            tiempoP1.Text = listaProcesos[0].RelojLogico.ToString();
            historialP1 = new ObservableCollection<Mensaje>();
            listaMensajesP1.ItemsSource = historialP1;

            historialP2 = new ObservableCollection<Mensaje>();
            tiempoP2.Text = listaProcesos[1].RelojLogico.ToString();
            listaMensajesP2.ItemsSource = historialP2;

            historialP3 = new ObservableCollection<Mensaje>();
            listaMensajesP3.ItemsSource = historialP3;
            tiempoP3.Text = listaProcesos[2].RelojLogico.ToString();
        }
        

        private void BotonEnviar_Click(object sender, RoutedEventArgs e)
        {
            if(procesoDestinoP1.SelectedItem == null)
            {
                MessageBox.Show("Error: Debe seleccionar un proceso destino para mandar el mensaje","ERROR Campo destino vacio",MessageBoxButton.OK);
                
            }
            else
            {
                if (tiempoP1 == null)
                {
                    MessageBox.Show("Error: Debe ingresar un tiempo de envio para mandar el mensaje", "ERROR Campo tiempo vacio", MessageBoxButton.OK);
                }
                else
                {
                    if(string.IsNullOrWhiteSpace(MensajeP1.Text))
                    {
                        MessageBox.Show("Error: Debe ingresar un mensaje con texto de envio para mandar el mensaje", "ERROR Campo texto de mensaje vacio", MessageBoxButton.OK);
                    }
                    else
                    {
                        listaProcesos[0].RelojLogico = Int32.Parse(tiempoP1.Text);

                        Mensaje mensajeAEnviar = new Mensaje
                        {
                            Origen = listaProcesos[0],
                            Destino = procesoDestinoP1.SelectedItem as HiloProcesador,
                            UnidadTiempo = Int32.Parse(tiempoP1.Text),
                            Texto = string.Concat("Proceso: ",listaProcesos[0].Identificador.ToString(),MensajeP1.Text)
                        };

                        EnviarMensaje(mensajeAEnviar);
                        ActualizarTiemposHistorial();
                    } 
                }
            }
        }

        private void BotonEnviarP2_Click(object sender, RoutedEventArgs e)
        {
            if (procesoDestinoP2.SelectedItem == null)
            {
                MessageBox.Show("Error: Debe seleccionar un proceso destino para mandar el mensaje", "ERROR Campo destino vacio", MessageBoxButton.OK);

            }
            else
            {
                if (tiempoP2 == null)
                {
                    MessageBox.Show("Error: Debe ingresar un tiempo de envio para mandar el mensaje", "ERROR Campo tiempo vacio", MessageBoxButton.OK);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(MensajeP2.Text))
                    {
                        MessageBox.Show("Error: Debe ingresar un mensaje con texto de envio para mandar el mensaje", "ERROR Campo texto de mensaje vacio", MessageBoxButton.OK);
                    }
                    else
                    {
                        listaProcesos[1].RelojLogico = Int32.Parse(tiempoP2.Text);

                        Mensaje mensajeAEnviar = new Mensaje
                        {
                            Origen = listaProcesos[1],
                            Destino = procesoDestinoP2.SelectedItem as HiloProcesador,
                            UnidadTiempo = Int32.Parse(tiempoP2.Text),
                            Texto = string.Concat("Proceso: ", listaProcesos[1].Identificador.ToString(), MensajeP2.Text)
                        };

                        EnviarMensaje(mensajeAEnviar);
                        ActualizarTiemposHistorial();
                    }
                }
            }
        }

        private void BotonEnviarP3_Click(object sender, RoutedEventArgs e)
        {
            if (procesoDestinoP3.SelectedItem == null)
            {
                MessageBox.Show("Error: Debe seleccionar un proceso destino para mandar el mensaje", "ERROR Campo destino vacio", MessageBoxButton.OK);

            }
            else
            {
                if (tiempoP3 == null)
                {
                    MessageBox.Show("Error: Debe ingresar un tiempo de envio para mandar el mensaje", "ERROR Campo tiempo vacio", MessageBoxButton.OK);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(MensajeP3.Text))
                    {
                        MessageBox.Show("Error: Debe ingresar un mensaje con texto de envio para mandar el mensaje", "ERROR Campo texto de mensaje vacio", MessageBoxButton.OK);
                    }
                    else
                    {
                        listaProcesos[2].RelojLogico = Int32.Parse(tiempoP3.Text);

                        Mensaje mensajeAEnviar = new Mensaje
                        {
                            Origen = listaProcesos[2],
                            Destino = procesoDestinoP3.SelectedItem as HiloProcesador,
                            UnidadTiempo = Int32.Parse(tiempoP3.Text),
                            Texto = string.Concat("Proceso: ", listaProcesos[2].Identificador.ToString(), MensajeP3.Text)
                        };

                        EnviarMensaje(mensajeAEnviar);
                        ActualizarTiemposHistorial();
                    }
                }
            }
        }

        private void EnviarMensaje(Mensaje mensaje)
        {
            if (mensaje.Origen.Identificador == 1)
            {
                listaProcesos[0].RelojLogico++;
                
                if (mensaje.UnidadTiempo <= listaProcesos[mensaje.Destino.Identificador-1].RelojLogico)
                {
                    RecibirMensaje(mensaje);
                    AgregarListaEspera(mensaje.Destino.Identificador);
  
                }
                else
                {
                    diccionarioEspera[mensaje.Destino.Identificador].Add(mensaje);
                }
                
            }
            else
            {

                if (mensaje.Origen.Identificador == 2)
                {
                    listaProcesos[1].RelojLogico++;

                    if (mensaje.UnidadTiempo <= listaProcesos[mensaje.Destino.Identificador-1].RelojLogico)
                    {
                        RecibirMensaje(mensaje);
                        AgregarListaEspera(mensaje.Destino.Identificador);

                    }
                    else
                    {
                        diccionarioEspera[mensaje.Destino.Identificador].Add(mensaje);
                    }
                }
                else
                {

                    if (mensaje.Origen.Identificador == 3)
                    {
                        listaProcesos[2].RelojLogico++;

                        if (mensaje.UnidadTiempo <= listaProcesos[mensaje.Destino.Identificador-1].RelojLogico)
                        {
                            RecibirMensaje(mensaje);
                            AgregarListaEspera(mensaje.Destino.Identificador);

                        }
                        else
                        {
                            diccionarioEspera[mensaje.Destino.Identificador].Add(mensaje);
                        }
                    }
                }
            }
        }

        public void AgregarListaEspera(int procesoDestino)
        {
            int numeroMensajes = diccionarioEspera[procesoDestino].Count();

            if (numeroMensajes > 0)
            {
                foreach (Mensaje mensajeEnColaEspera in diccionarioEspera[procesoDestino])
                {
                    if (mensajeEnColaEspera.UnidadTiempo <= listaProcesos[procesoDestino - 1].RelojLogico)
                    {
                        RecibirMensaje(mensajeEnColaEspera);
                        diccionarioEspera[procesoDestino].Remove(mensajeEnColaEspera);
                        break;
                    }
                }
            }
        }

        private void RecibirMensaje(Mensaje mensaje) 
        {
            int tiempoMayor = 0;

            if(mensaje.Origen.Identificador == 1)
            {
                if(mensaje.Destino.Identificador == 2)
                {
                    tiempoMayor = Math.Max(listaProcesos[1].RelojLogico, mensaje.UnidadTiempo);
                    listaProcesos[1].RelojLogico = tiempoMayor + 1;
                    historialP2.Add(mensaje);
                }
                else
                {
                    if (mensaje.Destino.Identificador == 3)
                    {
                        tiempoMayor = Math.Max(listaProcesos[2].RelojLogico, mensaje.UnidadTiempo);
                        listaProcesos[2].RelojLogico = tiempoMayor + 1;
                        historialP3.Add(mensaje);
                    }
                }
            }
            else
            {
                if (mensaje.Origen.Identificador == 2)
                {
                    if (mensaje.Destino.Identificador == 1)
                    {
                        tiempoMayor = Math.Max(listaProcesos[0].RelojLogico, mensaje.UnidadTiempo);
                        listaProcesos[0].RelojLogico = tiempoMayor + 1;
                        historialP1.Add(mensaje);
                    }
                    else
                    {
                        if (mensaje.Destino.Identificador == 3)
                        {
                            tiempoMayor = Math.Max(listaProcesos[2].RelojLogico, mensaje.UnidadTiempo);
                            listaProcesos[2].RelojLogico = tiempoMayor + 1;
                            historialP3.Add(mensaje);
                        }
                    }
                }
                else
                {
                    if(mensaje.Origen.Identificador == 3)
                    {
                        if (mensaje.Destino.Identificador == 1)
                        {
                            tiempoMayor = Math.Max(listaProcesos[0].RelojLogico, mensaje.UnidadTiempo);
                            listaProcesos[0].RelojLogico = tiempoMayor + 1;
                            historialP1.Add(mensaje);
                        }
                        else
                        {
                            if (mensaje.Destino.Identificador == 2)
                            {
                                tiempoMayor = Math.Max(listaProcesos[1].RelojLogico, mensaje.UnidadTiempo);
                                listaProcesos[1].RelojLogico = tiempoMayor + 1;
                                historialP2.Add(mensaje);
                            }
                        }
                    }
                }
            }
        }
        
        public void ActualizarTiemposHistorial()
        {
            tiempoP1.Text = listaProcesos[0].RelojLogico.ToString();
            listaMensajesP1.ItemsSource = historialP1;

            tiempoP2.Text = listaProcesos[1].RelojLogico.ToString();
            listaMensajesP2.ItemsSource = historialP2;

            tiempoP3.Text = listaProcesos[2].RelojLogico.ToString();
            listaMensajesP3.ItemsSource = historialP3;
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
