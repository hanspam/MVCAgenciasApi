using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgenciaPrueba.Models;

namespace AgenciaPrueba.Controllers
{
    public class ClienteViajesController : ApiController
    {
        private AgenciaViajeEntities1 db = new AgenciaViajeEntities1();

        // GET: api/ClienteViajes
        public IQueryable<ClienteViaje> GetClienteViajes()
        {
            return db.ClienteViajes;
        }

        // GET: api/ClienteViajes/5
        [ResponseType(typeof(ClienteViaje))]
        public IHttpActionResult GetClienteViaje(int id)
        {
            ClienteViaje clienteViaje = db.ClienteViajes.Find(id);
            if (clienteViaje == null)
            {
                return NotFound();
            }

            return Ok(clienteViaje);
        }

        // PUT: api/ClienteViajes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClienteViaje(int id, ClienteViaje clienteViaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clienteViaje.id)
            {
                return BadRequest();
            }

            db.Entry(clienteViaje).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteViajeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClienteViajes
        [ResponseType(typeof(ClienteViaje))]
        public IHttpActionResult PostClienteViaje(ClienteViaje clienteViaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClienteViajes.Add(clienteViaje);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clienteViaje.id }, clienteViaje);
        }

        // DELETE: api/ClienteViajes/5
        [ResponseType(typeof(ClienteViaje))]
        public IHttpActionResult DeleteClienteViaje(int id)
        {
            ClienteViaje clienteViaje = db.ClienteViajes.Find(id);
            if (clienteViaje == null)
            {
                return NotFound();
            }

            db.ClienteViajes.Remove(clienteViaje);
            db.SaveChanges();

            return Ok(clienteViaje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteViajeExists(int id)
        {
            return db.ClienteViajes.Count(e => e.id == id) > 0;
        }
    }
}