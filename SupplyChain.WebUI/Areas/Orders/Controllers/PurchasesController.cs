using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SupplyChain.Core;
using SupplyChain.Infrastructure;

namespace SupplyChain.WebUI.Areas.Orders.Controllers
{
    public class PurchasesController : Controller
    {
        private SupplyChainContext db = new SupplyChainContext();

        // GET: Orders/Purchases
        public ActionResult Index()
        {
            var purchaseOrderHeader = db.PurchaseOrderHeader.Include(p => p.Supplier);
            return View(purchaseOrderHeader.ToList());
        }

        // GET: Orders/Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = db.PurchaseOrderHeader.Find(id);
            if (purchaseOrderHeader == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderHeader);
        }

        // GET: Orders/Purchases/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name");
            //ViewBag.SupplierList = this.db.Suppliers;
            ViewBag.SupplierList = this.db.Suppliers.Include(s => s.Products);
            return View();
        }

        // POST: Orders/Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<PurchaseOrderDetail> purchaseOrderHeader)
        {
            if (ModelState.IsValid)
            {
                //db.PurchaseOrderDetails.Add(purchaseOrderHeader);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", purchaseOrderHeader.SupplierId);
            return View(purchaseOrderHeader);
        }

        // GET: Orders/Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = db.PurchaseOrderHeader.Find(id);
            if (purchaseOrderHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", purchaseOrderHeader.SupplierId);
            return View(purchaseOrderHeader);
        }

        // POST: Orders/Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderDate,SupplierId")] PurchaseOrderHeader purchaseOrderHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrderHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", purchaseOrderHeader.SupplierId);
            return View(purchaseOrderHeader);
        }

        // GET: Orders/Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = db.PurchaseOrderHeader.Find(id);
            if (purchaseOrderHeader == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderHeader);
        }

        // POST: Orders/Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrderHeader purchaseOrderHeader = db.PurchaseOrderHeader.Find(id);
            db.PurchaseOrderHeader.Remove(purchaseOrderHeader);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public JsonResult GetSupplierAndProducts()
        //{
        //    return Json();
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class Something
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
