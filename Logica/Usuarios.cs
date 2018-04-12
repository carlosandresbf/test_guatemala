using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data; // incluyo la libreria Data para agregar el DataSet
using Datos; //incluyo la capa de datos

namespace Logica
{
    public class Usuarios : Conexion  //Usuarios hereda de la clase conexion y podemos usar sus metodos y atributos
    {

        public DataSet Iniciarsesion(string formNick, string formpassword)
        { //creamos el metodo para iniciar sesion y recibe el nick y password

            //creamos la consulta sql
            string consultasql = "select * from usuarios where nick ='" + formNick + "' and password ='" + formpassword + "'";
            DataSet resultadosconsulta = ConsultarSQL(consultasql); //enviamos la consulta mediante el metodo ConsultarSQL 
                                                                    //heredado de conexion. la respuesta se guarda en la variable
            return resultadosconsulta;//retornamos la variable
        }// cierre metodo iniciar sesion

    }//cierre clase
} // cierre namespace
