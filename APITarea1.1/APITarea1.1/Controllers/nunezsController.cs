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
using APITarea1._1.Models;

namespace APITarea1._1.Controllers
{
    public class nunezsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/nunezs
        [Authorize]
        public IQueryable<nunez> Getnunezs()
        {
            return db.nunezs;
        }

        // GET: api/nunezs/5
        [Authorize]
        [ResponseType(typeof(nunez))]
        public IHttpActionResult Getnunez(int id)
        {
            nunez nunez = db.nunezs.Find(id);
            if (nunez == null)
            {
                return NotFound();
            }

            return Ok(nunez);
        }

        // PUT: api/nunezs/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putnunez(int id, nunez nunez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nunez.nunezID)
            {
                return BadRequest();
            }

            db.Entry(nunez).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nunezExists(id))
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

        // POST: api/nunezs
        [Authorize]
        [ResponseType(typeof(nunez))]
        public IHttpActionResult Postnunez(nunez nunez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.nunezs.Add(nunez);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nunez.nunezID }, nunez);
        }

        // DELETE: api/nunezs/5
        [Authorize]
        [ResponseType(typeof(nunez))]
        public IHttpActionResult Deletenunez(int id)
        {
            nunez nunez = db.nunezs.Find(id);
            if (nunez == null)
            {
                return NotFound();
            }

            db.nunezs.Remove(nunez);
            db.SaveChanges();

            return Ok(nunez);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool nunezExists(int id)
        {
            return db.nunezs.Count(e => e.nunezID == id) > 0;
        }
    }
}