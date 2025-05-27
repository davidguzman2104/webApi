using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ApiRestItem.Models
{
    public class clsItems
    {
        public int id_item { get; set; }

        public string nombre_item { get; set; }

        public string foto { get; set; }

        public string estado_item { get; set; }

        public string ubicacion_item { get; set; }

        public string disponibilidad_entrega { get; set; }

        public int num_control { get; set; }

        public string nombre_alumno { get; set; }


        string cadConn = ConfigurationManager.ConnectionStrings["items_academicos"].ConnectionString;
        public clsItems()
        {

        }
        public clsItems(int id_item, string nombre, string foto,string status,string ubicacion, string disponibilidad_entrega )
        {

            this.id_item = id_item;
            this.nombre_item = nombre;
            this.foto = foto;
            this.estado_item = status;
            this.ubicacion_item = ubicacion;
            this.disponibilidad_entrega = disponibilidad_entrega;
           
        }
        public DataSet spReporteItemsDisponibles()
        {
            string cadSQL = "CALL spReporteItemsDisponibles();";
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "spReporteItemsDisponibles");
            return ds;
        }
        public DataSet tableitem()
        {
            // Crear el comando SQL
            string cadSQL = "";
            cadSQL = "select * from vista_items_con_alumno";
            // Configuración de objetos de conexión
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            // Ejecución y salida
            da.Fill(ds, "vista_items_con_alumno");
            return ds;
        }
        public DataSet spInsertarItem()
        {
            string sql = $"CALL spInsertarItem(" +
             $"{id_item}, " +
             $"'{nombre_item}', " +
             $"'{foto}', " +
             $"'{estado_item}', " +
             $"'{ubicacion_item}', " +
             $"'{disponibilidad_entrega}', " +
             $"{num_control}, " +
             $"'{nombre_alumno}');";

            var cnn = new MySqlConnection(cadConn);
            var da = new MySqlDataAdapter(sql, cnn);
            var ds = new DataSet();
            da.Fill(ds, "spInsertarItem");
            return ds;
        }

        public DataSet spObtenerItems()
        {
            string sql = "CALL spObtenerItems();";
            var cnn = new MySqlConnection(cadConn);
            var da = new MySqlDataAdapter(sql, cnn);
            var ds = new DataSet();
            da.Fill(ds, "spObtenerItems");
            return ds;
        }

        public DataSet spObtenerItemPorId(string id_item)
        {
            string sql = $"CALL spObtenerItemPorId({id_item});";
            var cnn = new MySqlConnection(cadConn);
            var da = new MySqlDataAdapter(sql, cnn);
            var ds = new DataSet();
            da.Fill(ds, "spObtenerItemPorId");
            return ds;
        }
        public DataSet spObtenerItemPorNombre(string nombre_item)
        {
            string sql = $"CALL spObtenerItemPorNombre('{nombre_item}');";
            var cnn = new MySqlConnection(cadConn);
            var da = new MySqlDataAdapter(sql, cnn);
            var ds = new DataSet();
            da.Fill(ds, "spObtenerItemPorNombre");
            return ds;
        }

        public DataSet spActualizarItem()
        {
            string sql = $"CALL spActualizarItem(" +
                 $"{id_item}, '{nombre_item}', '{foto}', '{estado_item}', " +
                 $"'{ubicacion_item}', '{disponibilidad_entrega}', {num_control});";

            var cnn = new MySqlConnection(cadConn);
            var da = new MySqlDataAdapter(sql, cnn);
            var ds = new DataSet();
            da.Fill(ds, "spActualizarItem");
            return ds;
        }

        public DataSet spEliminarItem(string id_item)
        {
            string sql = $"CALL spEliminarItem({id_item});";
            var cnn = new MySqlConnection(cadConn);
            var da = new MySqlDataAdapter(sql, cnn);
            var ds = new DataSet();
            da.Fill(ds, "spEliminarItem");
            return ds;
        }
    }
 }