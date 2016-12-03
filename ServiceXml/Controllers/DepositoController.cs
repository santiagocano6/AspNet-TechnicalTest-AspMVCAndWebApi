using System.Linq;
using System.Web.Http;
using Comunes.Models;
using ServiceXml.Models;

namespace ServiceXml.Controllers
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