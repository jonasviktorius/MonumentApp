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
    public class MaterialeTypersController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/MaterialeTypers
        public IQueryable<MaterialeTyper> GetMaterialeTyper()
        {
            return db.MaterialeTyper;
        }

        // GET: api/MaterialeTypers/5
        [ResponseType(typeof(MaterialeTyper))]
        public IHttpActionResult GetMaterialeTyper(int id)
        {
            MaterialeTyper materialeTyper = db.MaterialeTyper.Find(id);
            if (materialeTyper == null)
            {
                return NotFound();
            }

            return Ok(materialeTyper);
        }

        // PUT: api/MaterialeTypers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterialeTyper(int id, MaterialeTyper materialeTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materialeTyper.Materiale_Id)
            {
                return BadRequest();
            }

            db.Entry(materialeTyper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialeTyperExists(id))
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

        // POST: api/MaterialeTypers
        [ResponseType(typeof(MaterialeTyper))]
        public IHttpActionResult PostMaterialeTyper(MaterialeTyper materialeTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaterialeTyper.Add(materialeTyper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materialeTyper.Materiale_Id }, materialeTyper);
        }

        // DELETE: api/MaterialeTypers/5
        [ResponseType(typeof(MaterialeTyper))]
        public IHttpActionResult DeleteMaterialeTyper(int id)
        {
            MaterialeTyper materialeTyper = db.MaterialeTyper.Find(id);
            if (materialeTyper == null)
            {
                return NotFound();
            }

            db.MaterialeTyper.Remove(materialeTyper);
            db.SaveChanges();

            return Ok(materialeTyper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialeTyperExists(int id)
        {
            return db.MaterialeTyper.Count(e => e.Materiale_Id == id) > 0;
        }
    }
}