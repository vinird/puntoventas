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
    public class categoria_productoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: categoria_producto
        public ActionResult Index()
        {
            return View(db.categoria_producto.ToList());
        }

        // GET: categoria_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_producto categoria_producto = db.categoria_producto.Find(id);
            if (categoria_producto == null)
            {
                return HttpNotFound();
            }
            return View(categoria_producto);
        }

        // GET: categoria_producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categoria_producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,contenido")] categoria_producto categoria_producto)
        {
            if (ModelState.IsValid)
            {
                db.categoria_producto.Add(categoria_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria_producto);
        }

        // GET: categoria_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_producto categoria_producto = db.categoria_producto.Find(id);
            if (categoria_producto == null)
            {
                return HttpNotFound();
            }
            return View(categoria_producto);
        }

        // POST: categoria_producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,contenido")] categoria_producto categoria_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria_producto);
        }

        // GET: categoria_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria_producto categoria_producto = db.categoria_producto.Find(id);
            if (categoria_producto == null)
            {
                return HttpNotFound();
            }
            return View(categoria_producto);
        }

        // POST: categoria_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoria_producto categoria_producto = db.categoria_producto.Find(id);
            db.categoria_producto.Remove(categoria_producto);
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
