﻿using System;
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
    public class ViajesController : ApiController
    {
        private AgenciaViajeEntities1 db = new AgenciaViajeEntities1();

        // GET: api/Viajes
        public IQueryable<Viaje> GetViajes()
        {
            return db.Viajes;
        }

        // GET: api/Viajes/5
        [ResponseType(typeof(Viaje))]
        public IHttpActionResult GetViaje(int id)
        {
            Viaje viaje = db.Viajes.Find(id);
            if (viaje == null)
            {
                return NotFound();
            }

            return Ok(viaje);
        }

        // PUT: api/Viajes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViaje(int id, Viaje viaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viaje.CodigodeViaje)
            {
                return BadRequest();
            }

            db.Entry(viaje).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajeExists(id))
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

        // POST: api/Viajes
        [ResponseType(typeof(Viaje))]
        public IHttpActionResult PostViaje(Viaje viaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Viajes.Add(viaje);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ViajeExists(viaje.CodigodeViaje))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = viaje.CodigodeViaje }, viaje);
        }

        // DELETE: api/Viajes/5
        [ResponseType(typeof(Viaje))]
        public IHttpActionResult DeleteViaje(int id)
        {
            Viaje viaje = db.Viajes.Find(id);
            if (viaje == null)
            {
                return NotFound();
            }

            db.Viajes.Remove(viaje);
            db.SaveChanges();

            return Ok(viaje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViajeExists(int id)
        {
            return db.Viajes.Count(e => e.CodigodeViaje == id) > 0;
        }
    }
}