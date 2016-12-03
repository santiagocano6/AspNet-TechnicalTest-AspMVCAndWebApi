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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}