using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MERInventario_BDLC.Models;

namespace MERInventario_BDLC.Controllers
{
    public class PRODUCTOesController : Controller
    {
        private inventario_MEREntities db = new inventario_MEREntities();

        // GET: PRODUCTOes
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.CATEGORIA).Include(p => p.MARCA).Include(p => p.PROVEEDOR);
            return View(pRODUCTO.ToList());
        }

        // GET: PRODUCTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Create
        public ActionResult Create()
        {
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE");
            ViewBag.MAR_ID = new SelectList(db.MARCA, "MAR_ID", "MAR_NOMBRE");
            ViewBag.PROV_ID = new SelectList(db.PROVEEDOR, "PROV_ID", "PROV_NOMBRE");
            return View();
        }

        // POST: PRODUCTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROD_ID,CAT_ID,PROV_ID,MAR_ID,PROD_DESCRIPCION,PROD_CANTIDAD,PROD_PRECIO_UNI,PROD_LARGO,PROD_ANCHO,PROD_PROFUNDIDAD")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.MAR_ID = new SelectList(db.MARCA, "MAR_ID", "MAR_NOMBRE", pRODUCTO.MAR_ID);
            ViewBag.PROV_ID = new SelectList(db.PROVEEDOR, "PROV_ID", "PROV_NOMBRE", pRODUCTO.PROV_ID);
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.MAR_ID = new SelectList(db.MARCA, "MAR_ID", "MAR_NOMBRE", pRODUCTO.MAR_ID);
            ViewBag.PROV_ID = new SelectList(db.PROVEEDOR, "PROV_ID", "PROV_NOMBRE", pRODUCTO.PROV_ID);
            return View(pRODUCTO);
        }

        // POST: PRODUCTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROD_ID,CAT_ID,PROV_ID,MAR_ID,PROD_DESCRIPCION,PROD_CANTIDAD,PROD_PRECIO_UNI,PROD_LARGO,PROD_ANCHO,PROD_PROFUNDIDAD")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.MAR_ID = new SelectList(db.MARCA, "MAR_ID", "MAR_NOMBRE", pRODUCTO.MAR_ID);
            ViewBag.PROV_ID = new SelectList(db.PROVEEDOR, "PROV_ID", "PROV_NOMBRE", pRODUCTO.PROV_ID);
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
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
