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
    public class MonumentTypersController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/MonumentTypers
        public IQueryable<MonumentTyper> GetMonumentTyper()
        {
            return db.MonumentTyper;
        }

        // GET: api/MonumentTypers/5
        [ResponseType(typeof(MonumentTyper))]
        public IHttpActionResult GetMonumentTyper(int id)
        {
            MonumentTyper monumentTyper = db.MonumentTyper.Find(id);
            if (monumentTyper == null)
            {
                return NotFound();
            }

            return Ok(monumentTyper);
        }

        // PUT: api/MonumentTypers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonumentTyper(int id, MonumentTyper monumentTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monumentTyper.MonumentType_Id)
            {
                return BadRequest();
            }

            db.Entry(monumentTyper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonumentTyperExists(id))
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

        // POST: api/MonumentTypers
        [ResponseType(typeof(MonumentTyper))]
        public IHttpActionResult PostMonumentTyper(MonumentTyper monumentTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MonumentTyper.Add(monumentTyper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monumentTyper.MonumentType_Id }, monumentTyper);
        }
        [ResponseType(typeof(MonumentTyper))]
        [Route("api/PostMonumentTyper2")]
        [HttpPost]
        public HttpResponseMessage PostMonumentTyper2(MonumentTyperBinding monumentTyper)
        {
            if (!ModelState.IsValid || monumentTyper == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Monument typer var forkert... ");
            }

            var models1 = new List<MonumentTyper>();

            if (monumentTyper.Skulptur)
                models1.Add(new MonumentTyper { MonumentType = "Skulptur" });
            if (monumentTyper.Sokkel)
                models1.Add(new MonumentTyper { MonumentType = "Sokkel" });
            if (monumentTyper.Relief)
                models1.Add(new MonumentTyper { MonumentType = "Relief" });
            if (monumentTyper.Vandkunst)
                models1.Add(new MonumentTyper { MonumentType = "Vandkunst" });


            db.MonumentTyper.AddRange(models1);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, models1);
        }
        // DELETE: api/MonumentTypers/5
        [ResponseType(typeof(MonumentTyper))]
        public IHttpActionResult DeleteMonumentTyper(int id)
        {
            MonumentTyper monumentTyper = db.MonumentTyper.Find(id);
            if (monumentTyper == null)
            {
                return NotFound();
            }

            db.MonumentTyper.Remove(monumentTyper);
            db.SaveChanges();

            return Ok(monumentTyper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonumentTyperExists(int id)
        {
            return db.MonumentTyper.Count(e => e.MonumentType_Id == id) > 0;
        }
    }
}