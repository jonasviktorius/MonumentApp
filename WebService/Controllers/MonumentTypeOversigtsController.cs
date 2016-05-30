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
using WebService;

namespace WebService.Controllers
{
    public class MonumentTypeOversigtsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/MonumentTypeOversigts
        public IQueryable<MonumentTypeOversigt> GetMonumentTypeOversigt()
        {
            return db.MonumentTypeOversigt;
        }

        // GET: api/MonumentTypeOversigts/5
        [ResponseType(typeof(MonumentTypeOversigt))]
        public IHttpActionResult GetMonumentTypeOversigt(int id)
        {
            MonumentTypeOversigt monumentTypeOversigt = db.MonumentTypeOversigt.Find(id);
            if (monumentTypeOversigt == null)
            {
                return NotFound();
            }

            return Ok(monumentTypeOversigt);
        }

        // PUT: api/MonumentTypeOversigts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonumentTypeOversigt(int id, MonumentTypeOversigt monumentTypeOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monumentTypeOversigt.MonumentType_Id)
            {
                return BadRequest();
            }

            db.Entry(monumentTypeOversigt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonumentTypeOversigtExists(id))
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

        // POST: api/MonumentTypeOversigts
        [ResponseType(typeof(MonumentTypeOversigt))]
        public IHttpActionResult PostMonumentTypeOversigt(MonumentTypeOversigt monumentTypeOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MonumentTypeOversigt.Add(monumentTypeOversigt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MonumentTypeOversigtExists(monumentTypeOversigt.MonumentType_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = monumentTypeOversigt.MonumentType_Id }, monumentTypeOversigt);
        }

        // DELETE: api/MonumentTypeOversigts/5
        [ResponseType(typeof(MonumentTypeOversigt))]
        public IHttpActionResult DeleteMonumentTypeOversigt(int id)
        {
            MonumentTypeOversigt monumentTypeOversigt = db.MonumentTypeOversigt.Find(id);
            if (monumentTypeOversigt == null)
            {
                return NotFound();
            }

            db.MonumentTypeOversigt.Remove(monumentTypeOversigt);
            db.SaveChanges();

            return Ok(monumentTypeOversigt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonumentTypeOversigtExists(int id)
        {
            return db.MonumentTypeOversigt.Count(e => e.MonumentType_Id == id) > 0;
        }
    }
}