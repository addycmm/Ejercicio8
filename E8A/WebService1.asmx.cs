using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace E8A
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public int ModificarPersona(int id,
                                    string nombre,
                                    string apellido,
                                    string ci,
                                    string correo,
                                    string contrasenia,
                                    string departamento,
                                    string tipo)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdadriana";
                string usuario = "root";
                string password = "";
                string CadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                string query = "UPDATE persona SET nombre ='" + nombre + "', apellido ='" + apellido + "', ci ='" + ci + "', correo ='" + correo + "', contrasenia ='" + contrasenia + "', departamento ='" + departamento + "', tipo ='" + tipo + "' WHERE id = " + id;
                con.ConnectionString = CadenaConexion;
                con.Open();
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Se ha modificado la persona con id: " + id);
                return 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        //agregar persona
        [WebMethod]
        public string AgregarPersona(string nombre, string apellido, string ci, string correo, string contrasenia, string departamento, string tipo)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdadriana";
                string usuario = "root";
                string password = "";
                string CadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                con.ConnectionString = CadenaConexion;
                con.Open();
                string query = "INSERT INTO persona (nombre,apellido,ci,correo,contrasenia,departamento,tipo) VALUES ('" + nombre + "','" + apellido + "','" + ci + "','" + correo + "','" + contrasenia + "','" + departamento + "','" + tipo + "')";
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Se ha agregado una nueva persona.");
                return "hola";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        //eliminar persona
        [WebMethod]
        public string EliminarPersona(int id)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdadriana";
                string usuario = "root";
                string password = "";
                string CadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                con.ConnectionString = CadenaConexion;
                con.Open();
                string query = "DELETE FROM persona WHERE id = " + id;
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Se ha eliminado la persona con id: " + id);
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }
}
