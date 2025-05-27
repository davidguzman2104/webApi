using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ApiRestItem.Models
{
    public class clsAlumnoitm
    {
        public string num_control { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string ubicacion_alumno { get; set; }
        public string carrera { get; set; }
        public string mail { get; set; }
        public string foto { get; set; }
        public string id_item { get; set; }
        public string status { get; set; }
        public string ubicacion { get; set; }
        public string disponibilidad_entrega { get; set; }

        // Metodos y atributos de funcionalidad y seguridad
        string cadConn = ConfigurationManager.ConnectionStrings["items_academicos"].ConnectionString;
        public clsAlumnoitm()
        {
            //
        }
        public clsAlumnoitm(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contrasena = contraseña;
        }
        public clsAlumnoitm(string num_control, string nombre, string apellido_paterno, string apellido_materno, string usuario, string contraseña, string ubicacion_alumno, string carrera, string mail, string foto)
        {

            this.num_control = num_control;
            this.nombre = nombre;
            this.apellido_paterno = apellido_paterno;
            this.apellido_materno = apellido_materno;
            this.usuario = usuario;
            this.contrasena = contraseña;
            this.carrera = carrera;
            this.ubicacion_alumno = ubicacion_alumno;
            this.mail = mail;
            this.foto = foto;
        }

      

        public DataSet spValidarAcceso()
        {
            // Crear el comando SQL
            string cadSQL = "";
            cadSQL = "call spValidarAlumno('" + this.usuario + "','"
                                              + this.contrasena + "');";
            // Configuración de objetos de conexión
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            // Ejecución y salida
            da.Fill(ds, "spValidarAlumno");
            return ds;
        }
        public DataSet spInUsuario()
        {
            string cadSq = "CALL crear_alumno('" + this.num_control + "','" + this.nombre + "', '" + this.apellido_paterno +
    "', '" + this.apellido_materno + "', '" + this.usuario +
    "', '" + this.contrasena + "', '" + this.carrera +
    "','" + this.ubicacion_alumno + "','" + this.mail + "','" + this.foto + "')";
            // Coniguracion de los objetos
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSq, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "crear_alumno");
            //retorna  los datos recibidos
            return ds;

        }
        public DataSet spGetAlumnoByControl(string num_control)
        {
            string cadSQL = "CALL spGetAlumnoByControl('" + num_control + "');";
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "spGetAlumnoByControl");
            return ds;
        }
        public DataSet spUpdateAlumno()
        {
            string cadSQL = "CALL spUpdateAlumno('" + this.num_control + "','" + this.nombre + "', '" + this.apellido_paterno +
                "', '" + this.apellido_materno + "', '" + this.usuario +
                "', '" + this.contrasena + "', '" + this.carrera + "','" + this.ubicacion_alumno + 
                "','" + this.mail + "','" + this.foto + "')";
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "spUpdateAlumno");
            return ds;
        }
        public DataSet spDeleteAlumno(string num_control)
        {
            string cadSQL = "CALL spDeleteAlumno('" + num_control + "');";
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "spDeleteAlumno");
            return ds;
        }
    }


}

