using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//----------------------------------
using ApiRestItem.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Reflection;

namespace ApiRestItem.Controllers
{
    public class clsAlumnoController : ApiController
    {
        
        [HttpPost]
        [Route("check/usuario/spvalidaracceso")]
        public clsApiStatus spValidarAcceso([FromBody] clsAlumnoitm modelo)
        {
            // -----------------------------------------
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            // -----------------------------------------
            DataSet ds = new DataSet();
            try
            {
                // Creación del objeto del modelo clsUsuario
                clsAlumnoitm objusuario = new clsAlumnoitm(modelo.usuario, modelo.contrasena);
                ds = objusuario.spValidarAcceso();
                //configuracion del objeto de salida




                // Configuración del objeto de salida
                objRespuesta.statusExec = true;
                objRespuesta.ban = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                if (objRespuesta.ban == 1)
                {
                    objRespuesta.msg = "Usuario validado exitosamente";
                    jsonResp.Add("Alu_nombre_completo", ds.Tables[0].Rows[0][1].ToString());
                    jsonResp.Add("Alu_mail", ds.Tables[0].Rows[0][2].ToString());
                    jsonResp.Add("Alu_Carrera", ds.Tables[0].Rows[0][3].ToString());
                    jsonResp.Add("Alu_Foto", ds.Tables[0].Rows[0][4].ToString());
                    objRespuesta.datos = jsonResp;
                }
                else
                {
                    objRespuesta.msg = "Usuario no existente";
                    jsonResp.Add("msgData", "Acceso denegado, verificar");
                }


            }
            catch (Exception ex)
            {
                // Configuración del objeto de salida
                objRespuesta.statusExec = false;
                objRespuesta.ban = -1;
                objRespuesta.msg = "Error de conexion con el servicio de datos";
                jsonResp.Add("msgData", ex.Message.ToString());
                objRespuesta.datos = jsonResp;


            }

            return objRespuesta;

        }
        [HttpPost]
        [Route("check/usuario/spinusuario")]
        public clsApiStatus spInUsuario([FromBody] clsAlumnoitm modelo)
        {
            // definicion de los objetos y modelos
            clsApiStatus objrespuesta = new clsApiStatus();
            JObject jsonresp = new JObject();
            //------------------------------------
            DataSet ds = new DataSet(); try
            {
                // Crear el objeto del alumno con los datos del modelo recibido
                clsAlumnoitm objalumno = new clsAlumnoitm(
                    modelo.num_control,
                    modelo.nombre,
                    modelo.apellido_paterno,
                    modelo.apellido_materno,
                    modelo.usuario,
                    modelo.contrasena,
                    modelo.carrera,
                    modelo.ubicacion_alumno,
                    modelo.mail,
                    modelo.foto
                );

                // Llamada al procedimiento almacenado
                ds = objalumno.spInUsuario();

                objrespuesta.statusExec = true;
                objrespuesta.ban = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                if (objrespuesta.ban == 0)
                {
                    objrespuesta.msg = "Alumno registrado exitosamente";
                    jsonresp.Add("msData", "Alumno registrado exitosamente");
                }
                else
                {
                    objrespuesta.msg = "No se pudo registrar al alumno, verificar.";
                    jsonresp.Add("msData", "No se pudo registrar al alumno, verificar.");
                }

                objrespuesta.datos = jsonresp;
            }
            catch (Exception ex)
            {
                objrespuesta.statusExec = false;
                objrespuesta.ban = 1;
                objrespuesta.msg = "Error al insertar alumno";
                jsonresp.Add("msData", ex.Message);
                objrespuesta.datos = jsonresp;
            }

            return objrespuesta;

        }
        [HttpGet]
        [Route("alumnos/obtener/num_control")]
        public IHttpActionResult GetAlumnoByControl(string num_control)
        {
            clsAlumnoitm obj = new clsAlumnoitm();
            DataSet ds = obj.spGetAlumnoByControl(num_control);
            if (ds.Tables[0].Rows.Count > 0)
                return Ok(ds.Tables[0]);
            else
                return NotFound();
        }
        [HttpPut]
        [Route("alumnos/actualizar")]
        public clsApiStatus ActualizarAlumno([FromBody] clsAlumnoitm modelo)
        {
            clsApiStatus objrespuesta = new clsApiStatus();
            JObject jsonresp = new JObject();
            try
            {
                clsAlumnoitm objalumno = new clsAlumnoitm(
                    modelo.num_control,
                    modelo.nombre,
                    modelo.apellido_paterno,
                    modelo.apellido_materno,
                    modelo.usuario,
                    modelo.contrasena,
                    modelo.carrera,
                    modelo.ubicacion_alumno,
                    modelo.mail,
                    modelo.foto
                );

                DataSet ds = objalumno.spUpdateAlumno();
                objrespuesta.statusExec = true;
                objrespuesta.ban = 0;
                objrespuesta.msg = "Alumno actualizado exitosamente";
                jsonresp.Add("msData", "Alumno actualizado");
                objrespuesta.datos = jsonresp;
            }
            catch (Exception ex)
            {
                objrespuesta.statusExec = false;
                objrespuesta.ban = 1;
                objrespuesta.msg = "Error al actualizar alumno";
                jsonresp.Add("msData", ex.Message);
                objrespuesta.datos = jsonresp;
            }
            return objrespuesta;
        }
        [HttpDelete]
        [Route("alumnos/eliminar/num_control")]
        public clsApiStatus EliminarAlumno(string num_control)
        {
            clsApiStatus objrespuesta = new clsApiStatus();
            JObject jsonresp = new JObject();
            try
            {
                clsAlumnoitm objalumno = new clsAlumnoitm();
                DataSet ds = objalumno.spDeleteAlumno(num_control);

                objrespuesta.statusExec = true;
                objrespuesta.ban = 0;
                objrespuesta.msg = "Alumno eliminado exitosamente";
                jsonresp.Add("msData", "Alumno eliminado");
                objrespuesta.datos = jsonresp;
            }
            catch (Exception ex)
            {
                objrespuesta.statusExec = false;
                objrespuesta.ban = 1;
                objrespuesta.msg = "Error al eliminar alumno";
                jsonresp.Add("msData", ex.Message);
                objrespuesta.datos = jsonresp;
            }
            return objrespuesta;
        }
       
    }
}