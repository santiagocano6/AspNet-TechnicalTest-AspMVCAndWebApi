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
using Comunes.Models;
using ServiceJson.Models;

namespace ServiceJson.Controllers
{
    public class DepositoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Deposito
        public IQueryable<DepositoModels> GetDepositoModels()
        {
            return db.DepositoModels;
        }

        // GET: api/Deposito/5
        [ResponseType(typeof(DepositoModels))]
        public IHttpActionResult GetDepositoModels(Guid id)
        {
            DepositoModels depositoModels = db.DepositoModels.Find(id);
            if (depositoModels == null)
            {
                return NotFound();
            }

            return Ok(depositoModels);
        }

        // PUT: api/Deposito/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepositoModels(Guid id, DepositoModels depositoModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != depositoModels.DepositoId)
            {
                return BadRequest();
            }

            db.Entry(depositoModels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoModelsExists(id))
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

        // POST: api/Deposito
        [ResponseType(typeof(DepositoModels))]
        public IHttpActionResult PostDepositoModels(DepositoModels depositoModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DepositoModels.Add(depositoModels);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepositoModelsExists(depositoModels.DepositoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = depositoModels.DepositoId }, depositoModels);
        }

        // DELETE: api/Deposito/5
        [ResponseType(typeof(DepositoModels))]
        public IHttpActionResult DeleteDepositoModels(Guid id)
        {
            DepositoModels depositoModels = db.DepositoModels.Find(id);
            if (depositoModels == null)
            {
                return NotFound();
            }

            db.DepositoModels.Remove(depositoModels);
            db.SaveChanges();

            return Ok(depositoModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepositoModelsExists(Guid id)
        {
            return db.DepositoModels.Count(e => e.DepositoId == id) > 0;
        }
    }
}