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
    public class PlaceringsOversigtsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/PlaceringsOversigts
        public IQueryable<PlaceringsOversigt> GetPlaceringsOversigt()
        {
            return db.PlaceringsOversigt;
        }

        // GET: api/PlaceringsOversigts/5
        [ResponseType(typeof(PlaceringsOversigt))]
        public IHttpActionResult GetPlaceringsOversigt(int id)
        {
            PlaceringsOversigt placeringsOversigt = db.PlaceringsOversigt.Find(id);
            if (placeringsOversigt == null)
            {
                return NotFound();
            }

            return Ok(placeringsOversigt);
        }

        // PUT: api/PlaceringsOversigts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlaceringsOversigt(int id, PlaceringsOversigt placeringsOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != placeringsOversigt.Placerings_Id)
            {
                return BadRequest();
            }

            db.Entry(placeringsOversigt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceringsOversigtExists(id))
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

        // POST: api/PlaceringsOversigts
        [ResponseType(typeof(PlaceringsOversigt))]
        public IHttpActionResult PostPlaceringsOversigt(PlaceringsOversigt placeringsOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlaceringsOversigt.Add(placeringsOversigt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlaceringsOversigtExists(placeringsOversigt.Placerings_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = placeringsOversigt.Placerings_Id }, placeringsOversigt);
        }

        // DELETE: api/PlaceringsOversigts/5
        [ResponseType(typeof(PlaceringsOversigt))]
        public IHttpActionResult DeletePlaceringsOversigt(int id)
        {
            PlaceringsOversigt placeringsOversigt = db.PlaceringsOversigt.Find(id);
            if (placeringsOversigt == null)
            {
                return NotFound();
            }

            db.PlaceringsOversigt.Remove(placeringsOversigt);
            db.SaveChanges();

            return Ok(placeringsOversigt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlaceringsOversigtExists(int id)
        {
            return db.PlaceringsOversigt.Count(e => e.Placerings_Id == id) > 0;
        }
    }
}