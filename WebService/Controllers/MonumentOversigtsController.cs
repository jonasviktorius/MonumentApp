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
    public class MonumentOversigtsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/MonumentOversigts
        public IQueryable<MonumentOversigt> GetMonumentOversigt()
        {
            return db.MonumentOversigt;
        }

        // GET: api/MonumentOversigts/5
        [ResponseType(typeof(MonumentOversigt))]
        public IHttpActionResult GetMonumentOversigt(int id)
        {
            MonumentOversigt monumentOversigt = db.MonumentOversigt.Find(id);
            if (monumentOversigt == null)
            {
                return NotFound();
            }

            return Ok(monumentOversigt);
        }

        // PUT: api/MonumentOversigts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonumentOversigt(int id, MonumentOversigt monumentOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monumentOversigt.Global_Id)
            {
                return BadRequest();
            }

            db.Entry(monumentOversigt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonumentOversigtExists(id))
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

        // POST: api/MonumentOversigts
        [ResponseType(typeof(MonumentOversigt))]
        public IHttpActionResult PostMonumentOversigt(MonumentOversigt monumentOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MonumentOversigt.Add(monumentOversigt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monumentOversigt.Global_Id }, monumentOversigt);
        }

        // DELETE: api/MonumentOversigts/5
        [ResponseType(typeof(MonumentOversigt))]
        public IHttpActionResult DeleteMonumentOversigt(int id)
        {
            MonumentOversigt monumentOversigt = db.MonumentOversigt.Find(id);
            if (monumentOversigt == null)
            {
                return NotFound();
            }

            db.MonumentOversigt.Remove(monumentOversigt);
            db.SaveChanges();

            return Ok(monumentOversigt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonumentOversigtExists(int id)
        {
            return db.MonumentOversigt.Count(e => e.Global_Id == id) > 0;
        }
    }
}