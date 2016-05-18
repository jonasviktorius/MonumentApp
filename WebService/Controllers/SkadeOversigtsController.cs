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
    public class SkadeOversigtsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/SkadeOversigts
        public IQueryable<SkadeOversigt> GetSkadeOversigt()
        {
            return db.SkadeOversigt;
        }

        // GET: api/SkadeOversigts/5
        [ResponseType(typeof(SkadeOversigt))]
        public IHttpActionResult GetSkadeOversigt(int id)
        {
            SkadeOversigt skadeOversigt = db.SkadeOversigt.Find(id);
            if (skadeOversigt == null)
            {
                return NotFound();
            }

            return Ok(skadeOversigt);
        }

        // PUT: api/SkadeOversigts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkadeOversigt(int id, SkadeOversigt skadeOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skadeOversigt.Skade_Id)
            {
                return BadRequest();
            }

            db.Entry(skadeOversigt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkadeOversigtExists(id))
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

        // POST: api/SkadeOversigts
        [ResponseType(typeof(SkadeOversigt))]
        public IHttpActionResult PostSkadeOversigt(SkadeOversigt skadeOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkadeOversigt.Add(skadeOversigt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skadeOversigt.Skade_Id }, skadeOversigt);
        }

        // DELETE: api/SkadeOversigts/5
        [ResponseType(typeof(SkadeOversigt))]
        public IHttpActionResult DeleteSkadeOversigt(int id)
        {
            SkadeOversigt skadeOversigt = db.SkadeOversigt.Find(id);
            if (skadeOversigt == null)
            {
                return NotFound();
            }

            db.SkadeOversigt.Remove(skadeOversigt);
            db.SaveChanges();

            return Ok(skadeOversigt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkadeOversigtExists(int id)
        {
            return db.SkadeOversigt.Count(e => e.Skade_Id == id) > 0;
        }
    }
}