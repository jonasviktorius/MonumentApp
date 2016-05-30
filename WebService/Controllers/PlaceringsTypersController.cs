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
    public class PlaceringsTypersController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/PlaceringsTypers
        public IQueryable<PlaceringsTyper> GetPlaceringsTyper()
        {
            return db.PlaceringsTyper;
        }

        // GET: api/PlaceringsTypers/5
        [ResponseType(typeof(PlaceringsTyper))]
        public IHttpActionResult GetPlaceringsTyper(int id)
        {
            PlaceringsTyper placeringsTyper = db.PlaceringsTyper.Find(id);
            if (placeringsTyper == null)
            {
                return NotFound();
            }

            return Ok(placeringsTyper);
        }

        // PUT: api/PlaceringsTypers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlaceringsTyper(int id, PlaceringsTyper placeringsTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != placeringsTyper.Placerings_Id)
            {
                return BadRequest();
            }

            db.Entry(placeringsTyper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceringsTyperExists(id))
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

        // POST: api/PlaceringsTypers
        [ResponseType(typeof(PlaceringsTyper))]
        public IHttpActionResult PostPlaceringsTyper(PlaceringsTyper placeringsTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlaceringsTyper.Add(placeringsTyper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = placeringsTyper.Placerings_Id }, placeringsTyper);
        }

        [ResponseType(typeof(PlaceringsTyper))]
        [Route("api/PostPlaceringsTyper2")]
        [HttpPost]
        public HttpResponseMessage PostPlaceringsTyper2(PlaceringsTyperBinding placeringsTyper)
        {
            if (!ModelState.IsValid || placeringsTyper == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Modellen var forkert... ");
            }

            var models = new List<PlaceringsTyper>();

            if (placeringsTyper.Bygning)
                models.Add(new PlaceringsTyper { Placering = "Bygning" });
            if(placeringsTyper.Facade)
                models.Add(new PlaceringsTyper { Placering = "Facade" });
            if (placeringsTyper.Jord)
                models.Add(new PlaceringsTyper { Placering = "Jord" });


            db.PlaceringsTyper.AddRange(models);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, models);
        }

        // DELETE: api/PlaceringsTypers/5
        [ResponseType(typeof(PlaceringsTyper))]
        public IHttpActionResult DeletePlaceringsTyper(int id)
        {
            PlaceringsTyper placeringsTyper = db.PlaceringsTyper.Find(id);
            if (placeringsTyper == null)
            {
                return NotFound();
            }

            db.PlaceringsTyper.Remove(placeringsTyper);
            db.SaveChanges();

            return Ok(placeringsTyper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlaceringsTyperExists(int id)
        {
            return db.PlaceringsTyper.Count(e => e.Placerings_Id == id) > 0;
        }
    }
}