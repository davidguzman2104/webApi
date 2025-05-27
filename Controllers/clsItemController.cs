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
    public class clsItemController : ApiController
    {
        // GET: clsItem
        [HttpGet]
        [Route("report/items/disponibles")]
        public clsApiStatus spReporteItemsDisponibles()
        {
            clsApiStatus respuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            DataSet ds = new DataSet();

            try
            {
                clsItems obj = new clsItems();
                ds = obj.spReporteItemsDisponibles();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    respuesta.statusExec = true;
                    respuesta.ban = 0;
                    respuesta.msg = "Items disponibles encontrados";

                    JArray lista = new JArray();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        JObject item = new JObject
                        {
                            ["id_item"] = row["id_item"].ToString(),
                            ["nombre_item"] = row["nombre_item"].ToString(),
                            ["ubicacion_item"] = row["ubicacion_item"].ToString(),
                            ["foto_item"] = row["foto_item"].ToString(),
                            ["estado_item"] = row["estado_item"].ToString(),
                            ["disponibilidad_entrega"] = row["disponibilidad_entrega"].ToString(),
                            ["num_control"] = row["num_control"].ToString(),
                            ["nombre_completo"] = row["nombre_completo"].ToString(),
                            ["carrera"] = row["carrera"].ToString(),
                            ["ubicacion_alumno"] = row["ubicacion_alumno"].ToString(),
                            ["mail"] = row["mail"].ToString(),
                            ["foto_alumno"] = row["foto_alumno"].ToString()
                        };
                        lista.Add(item);
                    }

                    jsonResp.Add("Items", lista);
                    respuesta.datos = jsonResp;
                }
                else
                {
                    respuesta.statusExec = true;
                    respuesta.ban = 1;
                    respuesta.msg = "No se encontraron items disponibles";
                    jsonResp.Add("msgData", "Sin resultados");
                    respuesta.datos = jsonResp;
                }
            }
            catch (Exception ex)
            {
                respuesta.statusExec = false;
                respuesta.ban = -1;
                respuesta.msg = "Error al consultar los datos";
                jsonResp.Add("msgData", ex.Message);
                respuesta.datos = jsonResp;
            }

            return respuesta;
        }

        [HttpPost, Route("insertar")]
        public clsApiStatus spInsertarItem([FromBody] clsItems modelo)
        {
            var resp = new clsApiStatus();
            var json = new JObject();
            try
            {
                var ds = modelo.spInsertarItem();
                int ban = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                if (ban == 0)
                {
                    resp.statusExec = true;
                    resp.ban = 0;
                    resp.msg = "Ítem registrado correctamente.";
                }
                else
                {
                    resp.statusExec = true;
                    resp.ban = ban;
                    resp.msg = "No se pudo registrar el ítem. Verifica datos.";
                }
            }
            catch (Exception ex)
            {
                resp.statusExec = false;
                resp.ban = 1;
                resp.msg = "Error al registrar ítem.";
                resp.datos = new JObject { ["error"] = ex.Message };
            }
            return resp;
        }

        [HttpGet, Route("obtener")]
        public IHttpActionResult ObtenerItems()
        {
            try
            {
                var ds = new clsItems().spObtenerItems();
                return Ok(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError,
                  new clsApiStatus
                  {
                      statusExec = false,
                      ban = 1,
                      msg = "Error al obtener ítems.",
                      datos = new JObject { ["error"] = ex.Message }
                  });
            }
        }

        [HttpGet, Route("obtener/{id}")]
        public IHttpActionResult ObtenerItemPorId(string id)
        {
            try
            {
                var ds = new clsItems().spObtenerItemPorId(id);
                if (ds.Tables[0].Rows.Count > 0)
                    return Ok(ds.Tables[0]);
                return Content(HttpStatusCode.NotFound,
                  new clsApiStatus
                  {
                      statusExec = true,
                      ban = 1,
                      msg = $"Item con ID {id} no encontrado.",
                      datos = null
                  });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError,
                  new clsApiStatus
                  {
                      statusExec = false,
                      ban = 1,
                      msg = "Error al buscar ítem.",
                      datos = new JObject { ["error"] = ex.Message }
                  });
            }
        }
        [RoutePrefix("api/items")]
        public class ItemsController : ApiController
        {
            [HttpGet]
            [Route("obtenerPorNombre/{nombre}")]
            public IHttpActionResult ObtenerItemPorNombre(string nombre)
            {
                try
                {
                    var ds = new clsItems().spObtenerItemPorNombre(nombre);
                    if (ds.Tables[0].Rows.Count > 0)
                        return Ok(ds.Tables[0]);

                    return Content(HttpStatusCode.NotFound,
                      new clsApiStatus
                      {
                          statusExec = true,
                          ban = 1,
                          msg = $"Item con nombre '{nombre}' no encontrado.",
                          datos = null
                      });
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.InternalServerError,
                      new clsApiStatus
                      {
                          statusExec = false,
                          ban = 1,
                          msg = "Error al buscar ítem.",
                          datos = new JObject { ["error"] = ex.Message }
                      });
                }
            }
        }

        [HttpPut, Route("actualizar")]
            public clsApiStatus ActualizarItem([FromBody] clsItems modelo)
            {
                var resp = new clsApiStatus();
                try
                {
                    var ds = modelo.spActualizarItem();
                    int ban = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    if (ban == 0)
                    {
                        resp.statusExec = true;
                        resp.ban = 0;
                        resp.msg = "Ítem actualizado correctamente.";
                    }
                    else
                    {
                        resp.statusExec = true;
                        resp.ban = ban;
                        resp.msg = "No se pudo actualizar el ítem.";
                    }
                }
                catch (Exception ex)
                {
                    resp.statusExec = false;
                    resp.ban = 1;
                    resp.msg = "Error al actualizar ítem.";
                    resp.datos = new JObject { ["error"] = ex.Message };
                }
                return resp;
            }

            [HttpDelete, Route("eliminar/{id}")]
            public clsApiStatus EliminarItem(string id)
            {
                var resp = new clsApiStatus();
                try
                {
                    var ds = new clsItems().spEliminarItem(id);
                    int ban = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    if (ban == 0)
                    {
                        resp.statusExec = true;
                        resp.ban = 0;
                        resp.msg = "Ítem eliminado correctamente.";
                    }
                    else
                    {
                        resp.statusExec = true;
                        resp.ban = ban;
                        resp.msg = "No se pudo eliminar el ítem.";
                    }
                }
                catch (Exception ex)
                {
                    resp.statusExec = false;
                    resp.ban = 1;
                    resp.msg = "Error al eliminar ítem.";
                    resp.datos = new JObject { ["error"] = ex.Message };
                }
                return resp;
            }
            [HttpGet]
            [Route("items/todos")]
            public clsApiStatus GetItemsConAlumno()
            {
                clsApiStatus respuesta = new clsApiStatus();
                JObject jsonResp = new JObject();
                DataSet ds = new DataSet();

                try
                {
                    clsItems obj = new clsItems();
                    ds = obj.tableitem();

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        respuesta.statusExec = true;
                        respuesta.ban = 0;
                        respuesta.msg = "Items encontrados correctamente";

                        JArray lista = new JArray();

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            JObject item = new JObject();

                            foreach (DataColumn col in ds.Tables[0].Columns)
                            {
                                item[col.ColumnName] = row[col].ToString();
                            }

                            lista.Add(item);
                        }

                        jsonResp.Add("Items", lista);
                        respuesta.datos = jsonResp;
                    }
                    else
                    {
                        respuesta.statusExec = true;
                        respuesta.ban = 1;
                        respuesta.msg = "No se encontraron registros en la vista";
                        jsonResp.Add("msgData", "Sin resultados");
                        respuesta.datos = jsonResp;
                    }
                }
                catch (Exception ex)
                {
                    respuesta.statusExec = false;
                    respuesta.ban = -1;
                    respuesta.msg = "Error al consultar los datos";
                    jsonResp.Add("msgData", ex.Message);
                    respuesta.datos = jsonResp;
                }

                return respuesta;
            }


        }
    }
