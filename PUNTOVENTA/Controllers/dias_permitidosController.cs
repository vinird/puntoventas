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
    public class dias_permitidosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: dias_permitidos
        public ActionResult Index()
        {
            return View(db.dias_permitidos.ToList());
        }

        // GET: dias_permitidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dias_permitidos dias_permitidos = db.dias_permitidos.Find(id);
            if (dias_permitidos == null)
            {
                return HttpNotFound();
            }
            return View(dias_permitidos);
        }

        // GET: dias_permitidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dias_permitidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,dias")] dias_permitidos dias_permitidos)
        {
            if (ModelState.IsValid)
            {
                db.dias_permitidos.Add(dias_permitidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dias_permitidos);
        }

        // GET: dias_permitidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dias_permitidos dias_permitidos = db.dias_permitidos.Find(id);
            if (dias_permitidos == null)
            {
                return HttpNotFound();
            }
            return View(dias_permitidos);
        }

        // POST: dias_permitidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,dias")] dias_permitidos dias_permitidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dias_permitidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dias_permitidos);
        }

        // GET: dias_permitidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dias_permitidos dias_permitidos = db.dias_permitidos.Find(id);
            if (dias_permitidos == null)
            {
                return HttpNotFound();
            }
            return View(dias_permitidos);
        }

        // POST: dias_permitidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dias_permitidos dias_permitidos = db.dias_permitidos.Find(id);
            db.dias_permitidos.Remove(dias_permitidos);
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
