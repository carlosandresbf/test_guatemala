using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient; //Agregamos Librerias para conexion con SQlServer

namespace Datos
{
    public class Conexion
    {
        private SqlConnection conn; // Atributo para guardar la conexion con el Servidor
        private string mensaje; // Mensaje de respuesta

        public string Mensaje
        { //metodo publico para establecer y obtener el valor de mensaje
            get { return mensaje; }
            set { mensaje = value; }
        }

        public Conexion() { // Metodo constructor: Se ejecuta cuando se crea el objeto.
            //"Data Source=NOMBRESERVIDOR;Initial Catalog=NOMBREBASEDEDATOS;Integrated Security=True"
            string cadenaConexion = @"Data Source=071047PS01008\SQLEXPRESS;Initial Catalog=MyTest;Integrated Security=True";
            this.conn = new SqlConnection(cadenaConexion);
        }


        //privacidad publica   Devuelve DataSet con el resultado  
        public DataSet ConsultarSQL(string sentenciaSQL)
        { //metodo para consultar datos
            try{ // ejecutamos el codigo del Try y si ocurre algun error, automaticamente salta al catch

                //1. abrir la conexion
                conn.Open();
                //2. Enviar la sentencia por la conexion abierta
                SqlDataAdapter respuestaServidor = new SqlDataAdapter(sentenciaSQL, conn);
                //3. Crear el objeto de tipo DataSet donde estarán mis datos
                DataSet datos = new DataSet();
                //4. Llenar el DataSet con la respuesta del servidor
                respuestaServidor.Fill(datos, "DatosConsultados");
                //5. Devolvemos el mensaje de éxito y retornamos el DataSet
                mensaje = "Se ha consultado con éxito";
                return datos;
                            
            }catch(Exception error){ // Si ocurre un error en el try, entra al catch y devuelve el dataset vacio
                DataSet vacio = new DataSet();
                mensaje = "No se ha podido consultar. Error:" + error.Message;
                return vacio;
             }finally{ // el codigo del finally se ejecuta al final en caso de que hayan o no hayan errores.
                 conn.Close(); // Cierre conexion Servidor SQL
            }

        } //Cierre del metodo ConsultarSQL


    } //Cierre de la clase
} // Cierre del NameSpace
