using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GAP.Models;

namespace GAP.Controllers
{
    public class DepositoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Deposito
        public ActionResult Index()
        {
            return View(db.DepositoModels.ToList());
        }

        // GET: Deposito/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepositoModels depositoModels = db.DepositoModels.Find(id);
            if (depositoModels == null)
            {
                return HttpNotFound();
            }
            return View(depositoModels);
        }

        // GET: Deposito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deposito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepositoId,Nombre,Direccion")] DepositoModels depositoModels)
        {
            if (ModelState.IsValid)
            {
                depositoModels.DepositoId = Guid.NewGuid();
                db.DepositoModels.Add(depositoModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(depositoModels);
        }

        // GET: Deposito/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepositoModels depositoModels = db.DepositoModels.Find(id);
            if (depositoModels == null)
            {
                return HttpNotFound();
            }
            return View(depositoModels);
        }

        // POST: Deposito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepositoId,Nombre,Direccion")] DepositoModels depositoModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depositoModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depositoModels);
        }

        // GET: Deposito/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepositoModels depositoModels = db.DepositoModels.Find(id);
            if (depositoModels == null)
            {
                return HttpNotFound();
            }
            return View(depositoModels);
        }

        // POST: Deposito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DepositoModels depositoModels = db.DepositoModels.Find(id);
            db.DepositoModels.Remove(depositoModels);
            db.SaveChanges();
            return RedirectToAction("Index");
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
