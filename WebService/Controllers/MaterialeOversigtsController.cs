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
    public class MaterialeOversigtsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/MaterialeOversigts
        public IQueryable<MaterialeOversigt> GetMaterialeOversigt()
        {
            return db.MaterialeOversigt;
        }

        // GET: api/MaterialeOversigts/5
        [ResponseType(typeof(MaterialeOversigt))]
        public IHttpActionResult GetMaterialeOversigt(int id)
        {
            MaterialeOversigt materialeOversigt = db.MaterialeOversigt.Find(id);
            if (materialeOversigt == null)
            {
                return NotFound();
            }

            return Ok(materialeOversigt);
        }

        // PUT: api/MaterialeOversigts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterialeOversigt(int id, MaterialeOversigt materialeOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materialeOversigt.Materiale_Id)
            {
                return BadRequest();
            }

            db.Entry(materialeOversigt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialeOversigtExists(id))
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

        // POST: api/MaterialeOversigts
        [ResponseType(typeof(MaterialeOversigt))]
        public IHttpActionResult PostMaterialeOversigt(MaterialeOversigt materialeOversigt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaterialeOversigt.Add(materialeOversigt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MaterialeOversigtExists(materialeOversigt.Materiale_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = materialeOversigt.Materiale_Id }, materialeOversigt);
        }

        // DELETE: api/MaterialeOversigts/5
        [ResponseType(typeof(MaterialeOversigt))]
        public IHttpActionResult DeleteMaterialeOversigt(int id)
        {
            MaterialeOversigt materialeOversigt = db.MaterialeOversigt.Find(id);
            if (materialeOversigt == null)
            {
                return NotFound();
            }

            db.MaterialeOversigt.Remove(materialeOversigt);
            db.SaveChanges();

            return Ok(materialeOversigt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialeOversigtExists(int id)
        {
            return db.MaterialeOversigt.Count(e => e.Materiale_Id == id) > 0;
        }
    }
}