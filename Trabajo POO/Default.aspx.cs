using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; //Este es para crear dinámicamente la tabla
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;

namespace Trabajo_POO
{
    public partial class _Default : Page
    {

        int contadorAutos = 0;
        int contadorAviones = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Si no es postback, vamos a generar:
            /* -> Una lista donde se almacenen todas la lista de transporte y persista
             * -> Una variable de sesión booleana para saber si existe un auto en marcha en el momento
             * -> Una variable para almacenar el índice del vehículo utilizado
             * -> Una variable de tiempo para saber cuando comenzó a correr el cronómetro
            */
            if (!IsPostBack)
            {
                //Generamos la lista y la guardamos en la variable de sesión para continuar utilizandola
                List<Transporte> listaTransporte = new List<Transporte>();
                Session["ListaTransporte"] = listaTransporte;
                //Para saber si hay algún vehículo en marcha
                bool enMarcha = false;
                Session["EnMarcha"] = enMarcha;
                //Para almacenar cual es el vehículo en marcha
                int vehiculoEnUso = 0;
                Session["VehiculoEnUso"] = vehiculoEnUso;
                //El conteo de segundos para multiplicar por kms
                int tiempo = 0;
                Session["Tiempo"] = tiempo;
            }

            if (IsPostBack)
            {
                //Muestra la cantidad de objetos de cada tipo creados
                List<Transporte> listaTransporte = new List<Transporte>();
                listaTransporte = (List<Transporte>)Session["ListaTransporte"];

                //Conteo de cada tipo de vehículo para mostrar en pantalla
                foreach (Transporte transporte in listaTransporte)
                {
                    if(transporte is Automovil)
                    {
                        contadorAutos += 1;
                    }
                    else
                    {
                        contadorAviones += 1;
                    }

                    if(contadorAviones < 5)
                    {
                        this.lblAviones.Text = "Aviones actuales: ";
                        this.lblAviones.Text = this.lblAviones.Text + contadorAviones.ToString();
                    }
                    else
                    {
                        this.lblAviones.Text = "Cantidad máxima de aviones alcanzada! (5)";
                    }
                    if (contadorAutos < 5)
                    {
                        this.lblAutos.Text = "Autos actuales: ";
                        this.lblAutos.Text = this.lblAutos.Text + contadorAutos.ToString();
                    }
                    else
                    {
                        this.lblAutos.Text = "Cantidad máxima de autos alcanzada! (5)";
                    }
                }
            }
            
        }

        //Botón para guardar un AVIÓN
        protected void btnAceptarAvion_Click(object sender, EventArgs e)
        {
            //Creamos una lista donde almacenaremos lo guardado en la variable de sesión si no está vacía
            List<Transporte> listaTransporte = new List<Transporte>();
            listaTransporte = (List<Transporte>)Session["ListaTransporte"];

            if (contadorAviones < 5)
            {
                //Creamos un objeto AVION a través de los pasajeros pasados desde el TextBox
                Avion avion = new Avion(Int32.Parse(this.cantPasajeros.Text));

                //Le agregamos el objeto AVION
                listaTransporte.Add(avion);
                //Almacenamos nuevamente la lista a la variable de sesión
                Session["ListaTransporte"] = listaTransporte;
            }
            else
            {
                Response.Write("Límite de aviones alcanzado! (5)");
            }
        }

        //Botón para guardar un AUTO
        protected void btnAceptarAuto_Click(object sender, EventArgs e)
        {
            //Creamos una lista donde almacenaremos lo guardado en la variable de sesión si no está vacía
            List<Transporte> listaTransporte = new List<Transporte>();
            listaTransporte = (List<Transporte>)Session["ListaTransporte"];

            if (contadorAutos < 5)
            {
                //Creamos un objeto AUTOMOVIL a través de los pasajeros pasados desde el TextBox
                Automovil auto = new Automovil(Int32.Parse(this.cantPasajeros.Text));

                //Le agregamos el objeto AUTOMOVIL
                listaTransporte.Add(auto);
                //Almacenamos nuevamente la lista a la variable de sesión
                Session["ListaTransporte"] = listaTransporte;
            }
            else
            {
                Response.Write("Límite de autos alcanzado! (5)");
            }
        }

        //Botón para mostrar todos los objetos creados
        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            List<Transporte> listaTransporte = new List<Transporte>();
            listaTransporte = (List<Transporte>)Session["ListaTransporte"];

            if (listaTransporte.Count < 1)
            {
                Response.Write("Primero debe ingresar un transporte.");
            }
            else
            {
                //En caso de que haya algo en la lista, lo limpiamos
                listTransportes.Items.Clear();
                int iterador = 0;
                foreach (Transporte transporte in listaTransporte)
                {
                    iterador += 1;
                    if (transporte is Automovil)
                    {
                        this.listTransportes.Items.Add("Auto " + iterador);
                    }
                    else
                    {
                        this.listTransportes.Items.Add("Avión " + iterador);
                    }
                }
            }
        }

        //Botón para visualizar todos los datos de un objeto
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {         
            if (listTransportes.SelectedItem != null)
            {
                List<Transporte> listaTransporte = new List<Transporte>();
                listaTransporte = (List<Transporte>)Session["ListaTransporte"];

                int seleccion = listTransportes.SelectedIndex;
                if (listaTransporte[seleccion] is Automovil)
                {
                    Automovil auto = new Automovil(listaTransporte[seleccion].Pasajeros);
                    Response.Write($"Has seleccionado un AUTO (del tipo {auto.tipoDeVehiculo()}) con {listaTransporte[seleccion].Pasajeros} pasajeros." +
                        $"Realizó {listaTransporte[seleccion].KmsRecorridos} KMs.");
                }
                else
                {
                    Avion avion = new Avion(listaTransporte[seleccion].Pasajeros);
                    Response.Write($"Has seleccionado un AVIÓN (del tipo {avion.tipoDeVehiculo()}) con {listaTransporte[seleccion].Pasajeros} pasajeros." +
                        $"Realizó {listaTransporte[seleccion].KmsRecorridos} KMs.");
                }
            }
            else
            {
                Response.Write("Debe seleccionar un vehículo");
            }
        }

        //Función para iniciar el cronómetro
        protected void btnArrancar_Click(object sender, EventArgs e)
        {       
            //Verificamos que no haya ningún vehículo en marcha
            bool enMarcha = (bool)Session["EnMarcha"];

            if (enMarcha == false)
            {
                if (listTransportes.SelectedItem == null)
                {
                    Response.Write("Debe seleccionar un vehículo");

                }
                else
                {
                    List<Transporte> listaTransporte = new List<Transporte>();
                    listaTransporte = (List<Transporte>)Session["ListaTransporte"];
                    
                    this.lblSeleccionAuto.Text = "";
                    this.lblSeleccionAvion.Text = "";
                    
                    //Guardamos la posición del vehículo
                    int seleccion = listTransportes.SelectedIndex;
                    Session["VehiculoEnUso"] = seleccion;

                    //Damos aviso que hay un vehículo en marcha
                    enMarcha = true;
                    Session["EnMarcha"] = enMarcha;

                    if (listaTransporte[seleccion] is Automovil)
                    {
                        this.lblSeleccionAuto.Text = $"Has seleccionado el auto {seleccion+1}. Arrancando!";

                        //Almacenamos los segundos en un string, luego lo transformamos a int y finalmente guardamos en una variable de sesión
                        string tiempoString = DateTime.Now.ToString("ss");
                        int tiempo = int.Parse(tiempoString);
                        Session["Tiempo"] = tiempo;
                    }
                    else
                    {
                        this.lblSeleccionAvion.Text = $"Has seleccionado el avión {seleccion+1}. Arrancando!";

                        string tiempoString = DateTime.Now.ToString("ss");
                        int tiempo = int.Parse(tiempoString);
                        Session["Tiempo"] = tiempo;
                    }
                }
            }
            else
            {
                lblSeleccionAuto.Text = "Debe detener el anterior vehículo primero!";
                lblSeleccionAvion.Text = "";
            }
        }

        //Función para finalizar el cronómetro
        protected void btnDetener_Click(object sender, EventArgs e)
        {
            //Verificamos si hay efectivamente un vehículo en marcha
            bool enMarcha = (bool)Session["EnMarcha"];
            if (enMarcha == true)
            {
                //Cambiamos el estado para que el próximo vehículo pueda iniciar la marcha
                enMarcha = false;
                Session["EnMarcha"] = enMarcha;

                //Verificamos cuál era el vehículo en marcha
                int seleccion = (int)Session["VehiculoEnUso"];
                
                //Verificamos cual era el tiempo de inicio
                int tiempoInicio = (int)Session["Tiempo"];

                //Guardamos el tiempo de stop y lo parseamos a int
                string tiempoString = DateTime.Now.ToString("ss");
                int tiempoLlegada = int.Parse(tiempoString);

                //Resta entre tiempo de llegada y salida
                int tiempoTotal = tiempoLlegada - tiempoInicio;

                Session["Tiempo"] = tiempoTotal;


                List<Transporte> listaTransporte = new List<Transporte>();
                listaTransporte = (List<Transporte>)Session["ListaTransporte"];
                int vehiculo = (int)Session["VehiculoEnUso"];
                if (listaTransporte[vehiculo] is Automovil)
                {
                    //Almacenamos el tiempo en el objeto
                    Automovil auto = new Automovil(listaTransporte[seleccion].Pasajeros);
                    auto.Avanzar(tiempoTotal);
                    listaTransporte[seleccion] = auto;
                    Session["ListaTransporte"] = listaTransporte;

                    this.lblSeleccionAuto.Text = $"Auto {seleccion + 1} detenido! Has hecho {auto.KmsRecorridos.ToString()} kms";
                }
                else
                {
                    Avion avion = new Avion(listaTransporte[seleccion].Pasajeros);
                    avion.Avanzar(tiempoTotal);
                    listaTransporte[seleccion] = avion;
                    Session["ListaTransporte"] = listaTransporte;

                    this.lblSeleccionAvion.Text = $"Avion {seleccion + 1} detenido! Has hecho {avion.KmsRecorridos.ToString()} kms";
                }
            }
        }
                    
    }
}