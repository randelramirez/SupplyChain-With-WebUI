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
    public class SalesController : Controller
    {
        private SupplyChainContext context; //new SupplyChainContext(Helpers.WebConfigHelper.GetConnectionString("SupplyChainContext"));
        private UnitOfWork unitOfWork;  //new UnitOfWork(new SupplyChainContext(Helpers.WebConfigHelper.GetConnectionString("SupplyChainContext")));
        private Repository<SalesOrderHeader> repository;
        private EntityService<SalesOrderHeader> service;
        private Repository<Customer> customerRpository;
        private EntityService<Customer> customerService;

        public SalesController()
        {
            this.context = new SupplyChainContext(Helpers.WebConfigHelper.GetConnectionString("SupplyChainContext"));
            this.unitOfWork = new UnitOfWork(this.context);
            this.repository = new Repository<SalesOrderHeader>(this.context);
            this.service = new EntityService<SalesOrderHeader>(this.repository, unitOfWork);
            this.customerRpository = new Repository<Customer>(this.context);
            this.customerService = new EntityService<Customer>(this.customerRpository, this.unitOfWork);
        }

        // GET: Orders/Sales
        public ActionResult Index()
        {
            var salesOrderHeaders = this.service.GetAll(s => s.Customer);//context.SalesOrderHeaders.Include(s => s.Customer);
            return View(salesOrderHeaders.ToList());
        }

        // GET: Orders/Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrderHeader salesOrderHeader = this.service.Find(id.GetValueOrDefault());
            if (salesOrderHeader == null)
            {
                return HttpNotFound();
            }
            //var sales = this.service.One(s => s.Id == salesOrderHeader.Id && salesOrderHeader.CustomerId == s.Customer.Id, s => s.OrderDetails, s => s.Customer);
            var sales = this.service.One(s => s.Id == salesOrderHeader.Id,s => s.OrderDetails);
            return View(sales);
        }

        // GET: Orders/Sales/Create
        public ActionResult Create()
        {
            ViewBag.CustomerList = this.customerService.GetAll();
            //ViewBag.CustomerId = new SelectList(context.Customers, "Id", "Name");
            //return View(this.customerService.GetAll());
            return View();
        }

        // POST: Orders/Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<SalesOrderDetail> salesOrderDetails, int customerId)
        {
            if (ModelState.IsValid)
            {
                //context.SalesOrderHeaders.Add(salesOrderHeader);
                //context.SaveChanges();
                var sales = new SalesOrderHeader { OrderDate = DateTime.UtcNow, CustomerId = customerId, OrderDetails = salesOrderDetails };
                this.service.Create(sales);
                this.unitOfWork.Save();
   
                return RedirectToAction("Index");
            }

            //ViewBag.CustomerId = new SelectList(this.service..Customers, "Id", "Name", salesOrderHeader.CustomerId);
            return View();
        }

        // GET: Orders/Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrderHeader salesOrderHeader = context.SalesOrderHeaders.Find(id);
            if (salesOrderHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(context.Customers, "Id", "Name", salesOrderHeader.CustomerId);
            return View(salesOrderHeader);
        }

        // POST: Orders/Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderDate,CustomerId")] SalesOrderHeader salesOrderHeader)
        {
            if (ModelState.IsValid)
            {
                context.Entry(salesOrderHeader).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(context.Customers, "Id", "Name", salesOrderHeader.CustomerId);
            return View(salesOrderHeader);
        }

        // GET: Orders/Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrderHeader salesOrderHeader = context.SalesOrderHeaders.Find(id);
            if (salesOrderHeader == null)
            {
                return HttpNotFound();
            }
            return View(salesOrderHeader);
        }

        // POST: Orders/Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesOrderHeader salesOrderHeader = context.SalesOrderHeaders.Find(id);
            context.SalesOrderHeaders.Remove(salesOrderHeader);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
