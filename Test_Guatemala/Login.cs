using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Guatemala
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void validar(){
            if ( string.IsNullOrEmpty(txtUsuario.Text) | string.IsNullOrEmpty(txtPassword.Text) )
            {// Si el usuario o password estan vacios, mostraremos un mensaje de error
                MessageBox.Show("Ingresa ambos datos");
            }else{ //Si los campos de texto tienen datos, validamos el inicio de sesion
                try
                {
                    Logica.Usuarios objetoUsuario = new Logica.Usuarios(); // creamos un objeto de la clase usuario (Logica)
                    DataSet Result = objetoUsuario.Iniciarsesion(txtUsuario.Text, txtPassword.Text); //Usamos el metodo Iniciar sesion y pasamos como parametros el nick y el password del formulario
                    DataTable DatosResultantes = Result.Tables["DatosConsultados"]; //convertimos el Dataset en Datatable para leer los datos

                    int numeroRegistros = DatosResultantes.Rows.Count; //contamos la cantidad de resultados

                    if (numeroRegistros == 0)
                    { // si la cantidad de resultados es cero, es por que el usuario y password no coinciden con lo existente en la base de datos
                        MessageBox.Show("Acceso Denegado.");
                    }
                    else
                    { // si la cantidad de resultados es distinta de cero, es por que el usuario y password si existen en el sistema y se inicia sesion
                        MessageBox.Show("Bienvenido," + DatosResultantes.Rows[0]["nick"].ToString()); //mensaje de bienvenida
                        this.Hide();
                        Menu ventana = new Menu(); //se muestra la ventana del menu
                        ventana.ShowDialog();
                        this.Show();
                    }
                }
                catch (Exception Error)
                {
                    MessageBox.Show("Error!" + Error.Message);
                }
            
            }

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            validar(); // Usamos el Metodo Validar en el evento Click del boton iniciar sesion
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
