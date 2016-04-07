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
using SupplyChain.Infrastructure.Services;

namespace SupplyChain.WebUI.Areas.Orders.Controllers
{
    public class PurchasesController : Controller
    {
        private SupplyChainContext context; 
        private UnitOfWork unitOfWork;  
        private Repository<PurchaseOrderHeader> purchaseRepository;
        private EntityService<PurchaseOrderHeader> purchaseService;
        private Repository<Supplier> supplierRepository;
        private EntityService<Supplier> supplierService;

        //public PurchasesController(SupplyChainContext context, UnitOfWork unitOfWork, Repository<PurchaseOrderHeader> purchaseRepository,  EntityService<PurchaseOrderHeader> purchaseService, Repository<Supplier> supplierRepository, EntityService<Supplier> supplierService)
        //{

        //}

        public PurchasesController()
        {
            this.context = new SupplyChainContext(Helpers.WebConfigHelper.GetConnectionString("SupplyChainContext"));
            this.unitOfWork = new UnitOfWork(this.context);
            this.purchaseRepository = new Repository<PurchaseOrderHeader>(this.context);
            this.purchaseService = new EntityService<PurchaseOrderHeader>(this.purchaseRepository, this.unitOfWork);
            this.supplierRepository = new Repository<Supplier>(this.context);
            this.supplierService = new EntityService<Supplier>(this.supplierRepository, this.unitOfWork);
        }

        // GET: Orders/Purchases
        public ActionResult Index()
        {
            var purchaseOrderHeader = this.purchaseService.GetAll();
            return View(purchaseOrderHeader.ToList());
        }

        // GET: Orders/Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = this.purchaseService.Find(id.GetValueOrDefault());
            if (purchaseOrderHeader == null)
            {
                return HttpNotFound();
            }
            return View(this.purchaseService.One(p => p.Id == purchaseOrderHeader.Id, p => p.PurchaseOrderDetails, p => p.Supplier.Products));
        }

        // GET: Orders/Purchases/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(this.supplierService.GetAll(), "Id", "Name");
            //ViewBag.SupplierList = this.db.Suppliers;
            ViewBag.SupplierList = this.supplierService.GetAll(s => s.Products);
            return View();
        }

        // POST: Orders/Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<PurchaseOrderDetail> purchaseOrderDetails, int supplierId)
        {
            if (ModelState.IsValid)
            {
                var purchaseOrder = new PurchaseOrderHeader { OrderDate = DateTime.UtcNow, SupplierId = supplierId, PurchaseOrderDetails = purchaseOrderDetails };
                this.purchaseService.Create(purchaseOrder);
                this.unitOfWork.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", purchaseOrderHeader.SupplierId);
            return View(purchaseOrderDetails);
        }

        // GET: Orders/Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = this.purchaseService.Find(id.GetValueOrDefault());
            if (purchaseOrderHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(this.supplierService.GetAll(), "Id", "Name", purchaseOrderHeader.SupplierId);
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
                this.purchaseService.Update(purchaseOrderHeader);
                //db.Entry(purchaseOrderHeader).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(this.supplierService.GetAll(), "Id", "Name", purchaseOrderHeader.SupplierId);
            return View(purchaseOrderHeader);
        }

        // GET: Orders/Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = this.purchaseService.Find(id.GetValueOrDefault());
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
            PurchaseOrderHeader purchaseOrderHeader = this.purchaseService.Find(id);
            this.purchaseService.Delete(id);
            this.unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
