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
    public class PostNrTabelsController : ApiController
    {
        private MonumentContext db = new MonumentContext();

        // GET: api/PostNrTabels
        public IQueryable<PostNrTabel> GetPostNrTabel()
        {
            return db.PostNrTabel;
        }

        // GET: api/PostNrTabels/5
        [ResponseType(typeof(PostNrTabel))]
        public IHttpActionResult GetPostNrTabel(int id)
        {
            PostNrTabel postNrTabel = db.PostNrTabel.Find(id);
            if (postNrTabel == null)
            {
                return NotFound();
            }

            return Ok(postNrTabel);
        }

        // PUT: api/PostNrTabels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPostNrTabel(int id, PostNrTabel postNrTabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postNrTabel.PostNr)
            {
                return BadRequest();
            }

            db.Entry(postNrTabel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostNrTabelExists(id))
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

        // POST: api/PostNrTabels
        [ResponseType(typeof(PostNrTabel))]
        public IHttpActionResult PostPostNrTabel(PostNrTabel postNrTabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PostNrTabel.Add(postNrTabel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PostNrTabelExists(postNrTabel.PostNr))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = postNrTabel.PostNr }, postNrTabel);
        }

        // DELETE: api/PostNrTabels/5
        [ResponseType(typeof(PostNrTabel))]
        public IHttpActionResult DeletePostNrTabel(int id)
        {
            PostNrTabel postNrTabel = db.PostNrTabel.Find(id);
            if (postNrTabel == null)
            {
                return NotFound();
            }

            db.PostNrTabel.Remove(postNrTabel);
            db.SaveChanges();

            return Ok(postNrTabel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostNrTabelExists(int id)
        {
            return db.PostNrTabel.Count(e => e.PostNr == id) > 0;
        }
    }
}