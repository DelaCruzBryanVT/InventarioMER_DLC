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
    public class PRODUCTOS_HISTORICOController : Controller
    {
        private inventario_MEREntities db = new inventario_MEREntities();

        // GET: PRODUCTOS_HISTORICO
        public ActionResult Index()
        {
            var pRODUCTOS_HISTORICO = db.PRODUCTOS_HISTORICO.Include(p => p.PRODUCTO);
            return View(pRODUCTOS_HISTORICO.ToList());
        }

        // GET: PRODUCTOS_HISTORICO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS_HISTORICO pRODUCTOS_HISTORICO = db.PRODUCTOS_HISTORICO.Find(id);
            if (pRODUCTOS_HISTORICO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS_HISTORICO);
        }

        // GET: PRODUCTOS_HISTORICO/Create
        public ActionResult Create()
        {
            ViewBag.PROD_ID = new SelectList(db.PRODUCTO, "PROD_ID", "PROD_DESCRIPCION");
            return View();
        }

        // POST: PRODUCTOS_HISTORICO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HIST_ID,PROD_ID,HIST_FECHA_MODIFICACION,HIST_STOCK")] PRODUCTOS_HISTORICO pRODUCTOS_HISTORICO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOS_HISTORICO.Add(pRODUCTOS_HISTORICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROD_ID = new SelectList(db.PRODUCTO, "PROD_ID", "PROD_DESCRIPCION", pRODUCTOS_HISTORICO.PROD_ID);
            return View(pRODUCTOS_HISTORICO);
        }

        // GET: PRODUCTOS_HISTORICO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS_HISTORICO pRODUCTOS_HISTORICO = db.PRODUCTOS_HISTORICO.Find(id);
            if (pRODUCTOS_HISTORICO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROD_ID = new SelectList(db.PRODUCTO, "PROD_ID", "PROD_DESCRIPCION", pRODUCTOS_HISTORICO.PROD_ID);
            return View(pRODUCTOS_HISTORICO);
        }

        // POST: PRODUCTOS_HISTORICO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HIST_ID,PROD_ID,HIST_FECHA_MODIFICACION,HIST_STOCK")] PRODUCTOS_HISTORICO pRODUCTOS_HISTORICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTOS_HISTORICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROD_ID = new SelectList(db.PRODUCTO, "PROD_ID", "PROD_DESCRIPCION", pRODUCTOS_HISTORICO.PROD_ID);
            return View(pRODUCTOS_HISTORICO);
        }

        // GET: PRODUCTOS_HISTORICO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS_HISTORICO pRODUCTOS_HISTORICO = db.PRODUCTOS_HISTORICO.Find(id);
            if (pRODUCTOS_HISTORICO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS_HISTORICO);
        }

        // POST: PRODUCTOS_HISTORICO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTOS_HISTORICO pRODUCTOS_HISTORICO = db.PRODUCTOS_HISTORICO.Find(id);
            db.PRODUCTOS_HISTORICO.Remove(pRODUCTOS_HISTORICO);
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
