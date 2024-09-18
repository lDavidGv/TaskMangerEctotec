using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Common.Exceptions;
using TaskManager.Models;
using TaskManager.Repository;

namespace TaskManager.Controllers
{
    public class TareasController : ApiController
    {

        private tareasLogic _logic = new tareasLogic();

        // GET api/values
        public IHttpActionResult Get()
        {
                try
                {
                    var shippers = _logic.GetAll().Select(s => new tareasDTO
                    {
                        Id = s.Id,
                        Descripcion = s.Descripcion,
                        Titulo = s.Titulo,
                        Estado = s.Estado,
                        FechaCreacion = s.FechaCreacion
                    });
                    return Ok(shippers);
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
                }
            }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {

            try
            {
                var TAREA = _logic.Get(id);
                if (TAREA == null)
                {
                    throw new NotExistsException();
                }
                var tareadto = new tareasDTO
                {
                    Id = TAREA.Id,
                    Descripcion = TAREA.Descripcion,
                    Titulo = TAREA.Titulo,
                    Estado = TAREA.Estado,
                    FechaCreacion = TAREA.FechaCreacion
                };
                return Ok(tareadto);
            }
            catch (NotExistsException ex)
            {
                return Content(HttpStatusCode.NotFound, new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }



        // POST api/values
        public IHttpActionResult Post([FromBody] tareasRequest tareasRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Content(HttpStatusCode.BadRequest, new { ErrorMessage = "ocurrio un error, "+ message });
                }
                Tareas newTarea = new Tareas()
                {
                    FechaCreacion = DateTime.Now,
                    Descripcion = tareasRequest.Descripcion,
                    Estado = tareasRequest.Estado,
                    Titulo = tareasRequest.Titulo
                };
                _logic.Add(newTarea);
                return Content(HttpStatusCode.Created, newTarea);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody] tareasRequest tareasRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join("| ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Content(HttpStatusCode.BadRequest, new { ErrorMessage = "ocurrio un error, " + message });
                }

                var shipperUpdated = _logic.Get(tareasRequest.Id);
                if (shipperUpdated == null)
                {
                    throw new NotExistsException();
                }
                shipperUpdated.Estado = tareasRequest.Estado;
                shipperUpdated.Descripcion = tareasRequest.Descripcion;
                shipperUpdated.Titulo = tareasRequest.Titulo;
                shipperUpdated.FechaCreacion = DateTime.Now;

                _logic.Update(shipperUpdated);
                return Content(HttpStatusCode.OK, new { successMessage = "Tarea actualizada exitosamente!" });
            }
            catch (NotExistsException ex)
            {
                return Content(HttpStatusCode.NotFound, new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var tareaDeleted = _logic.Get(id);
                if (tareaDeleted == null)
                {
                    throw new NotExistsException();
                }
                _logic.Delete(tareaDeleted);
                return Content(HttpStatusCode.OK, tareaDeleted);
            }
            catch (NotExistsException ex)
            {
                return Content(HttpStatusCode.NotFound, new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
        }
    }
}
