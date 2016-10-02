using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PUNTOVENTA.Models;

namespace PUNTOVENTA.Controllers
{
    public class impuestoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: impuestoes
        public ActionResult Index()
        {
            return View(db.impuestoes.ToList());
        }

        // GET: impuestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            impuesto impuesto = db.impuestoes.Find(id);
            if (impuesto == null)
            {
                return HttpNotFound();
            }
            return View(impuesto);
        }

        // GET: impuestoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: impuestoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,porcentaje")] impuesto impuesto)
        {
            if (ModelState.IsValid)
            {
                db.impuestoes.Add(impuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(impuesto);
        }

        // GET: impuestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            impuesto impuesto = db.impuestoes.Find(id);
            if (impuesto == null)
            {
                return HttpNotFound();
            }
            return View(impuesto);
        }

        // POST: impuestoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,porcentaje")] impuesto impuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(impuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(impuesto);
        }

        // GET: impuestoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            impuesto impuesto = db.impuestoes.Find(id);
            if (impuesto == null)
            {
                return HttpNotFound();
            }
            return View(impuesto);
        }

        // POST: impuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            impuesto impuesto = db.impuestoes.Find(id);
            db.impuestoes.Remove(impuesto);
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
