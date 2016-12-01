using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GAP.Models;
using System.Collections;

namespace GAP.Controllers
{
    public class ArticuloController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable _ArticulosConMenorStock()
        {
            var articuloModels = db.ArticuloModels.Include(d => d.DepositoModels).
                OrderBy(x => (x.TotalEnBodega + x.TotalEnEstante)).Take(5);

            return articuloModels;
            //return View(articuloModels.ToList());
        }

        public IEnumerable _ArticulosConMayorStock()
        {
            var articuloModels = db.ArticuloModels.Include(d => d.DepositoModels).
                OrderByDescending(x => (x.TotalEnBodega + x.TotalEnEstante)).Take(5);

            return articuloModels;
            //return View(articuloModels.ToList());
        }

        // GET: Articulo
        public ActionResult Index()
        {
            var articuloModels = db.ArticuloModels.Include(a => a.DepositoModels);
            return View(articuloModels.ToList());
        }

        // GET: Articulo/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloModels articuloModels = db.ArticuloModels.Find(id);
            if (articuloModels == null)
            {
                return HttpNotFound();
            }
            return View(articuloModels);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            ViewBag.DepositoId = new SelectList(db.DepositoModels, "DepositoId", "Nombre");
            return View();
        }

        // POST: Articulo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticuloId,Nombre,Descripcion,Precio,TotalEnEstante,TotalEnBodega,DepositoId")] ArticuloModels articuloModels)
        {
            if (ModelState.IsValid)
            {
                articuloModels.ArticuloId = Guid.NewGuid();
                db.ArticuloModels.Add(articuloModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepositoId = new SelectList(db.DepositoModels, "DepositoId", "Nombre", articuloModels.DepositoId);
            return View(articuloModels);
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloModels articuloModels = db.ArticuloModels.Find(id);
            if (articuloModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepositoId = new SelectList(db.DepositoModels, "DepositoId", "Nombre", articuloModels.DepositoId);
            return View(articuloModels);
        }

        // POST: Articulo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticuloId,Nombre,Descripcion,Precio,TotalEnEstante,TotalEnBodega,DepositoId")] ArticuloModels articuloModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articuloModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepositoId = new SelectList(db.DepositoModels, "DepositoId", "Nombre", articuloModels.DepositoId);
            return View(articuloModels);
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloModels articuloModels = db.ArticuloModels.Find(id);
            if (articuloModels == null)
            {
                return HttpNotFound();
            }
            return View(articuloModels);
        }

        // POST: Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ArticuloModels articuloModels = db.ArticuloModels.Find(id);
            db.ArticuloModels.Remove(articuloModels);
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
