using Comunes.Models;
using ServiceJson.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace ServiceJson.Controllers
{
    public class ArticuloController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Articulo
        public IQueryable<ArticuloModels> GetArticuloModels()
        {
            return db.ArticuloModels;
        }

        // GET: api/Articulo
        public IQueryable<ArticuloModels> GetArticuloModels(Guid id)
        {
            return db.ArticuloModels.Where(x => x.DepositoId == id);
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
