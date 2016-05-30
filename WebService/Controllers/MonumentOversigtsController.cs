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
using WebService.Models.Binding;

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

        [ResponseType(typeof(MonumentOversigt))]
        [HttpPost]
        [Route("api/v2/opretmonument")]
        public HttpResponseMessage OpretMonument(MonumentBinding model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Modellen er ikke vaid...");
            }

            var monument = new MonumentOversigt
            {
                Adresse = model.Adresse,
                Bevaringsværdi = model.Bevaringsværdi,
                Navn = model.Navn,
                Note = model.Note,
                PostNr = model.PostNr
            };

            db.MonumentOversigt.Add(monument);
            db.SaveChanges();

            if (model.Jord)
                db.PlaceringsOversigt.Add(new PlaceringsOversigt { Global_Id = monument.Global_Id, Placerings_Id = 1 });

            if (model.Facade)
                db.PlaceringsOversigt.Add(new PlaceringsOversigt { Global_Id = monument.Global_Id, Placerings_Id = 2 });

            if (model.Bygning)
                db.PlaceringsOversigt.Add(new PlaceringsOversigt { Global_Id = monument.Global_Id, Placerings_Id = 3 });

            db.SaveChanges();


            return Request.CreateResponse(HttpStatusCode.OK);
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