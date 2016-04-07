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

namespace SupplyChain.WebUI.Areas.BusinessPartners.Controllers
{
    public class CustomersController : Controller
    {
        private SupplyChainContext context; //new SupplyChainContext(Helpers.WebConfigHelper.GetConnectionString("SupplyChainContext"));
        private UnitOfWork unitOfWork;  //new UnitOfWork(new SupplyChainContext(Helpers.WebConfigHelper.GetConnectionString("SupplyChainContext")));
        private Repository<Customer> repository;
        private EntityService<Customer> service;

        public CustomersController()
        {
            this.context = new SupplyChainContext(Helpers.WebConfigHelper.GetConnectionString("SupplyChainContext"));
            this.repository = new Repository<Customer>(this.context);
            this.unitOfWork = new UnitOfWork(this.context);
            this.service = new EntityService<Customer>(this.repository, unitOfWork);
        }

        // GET: BusinessPartners/Customers
        public ActionResult Index()
        {
        
            return View(this.service.GetAll());
        }

        // GET: BusinessPartners/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = this.service.Find(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: BusinessPartners/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessPartners/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Customers.Add(customer);
                //db.SaveChanges();
                this.service.Create(customer);
                this.service.Save();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: BusinessPartners/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = this.service.Find(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: BusinessPartners/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                this.service.Update(customer);
                this.service.Save();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: BusinessPartners/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = this.service.Find(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: BusinessPartners/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Customer customer = this.service.Find(id);
            this.service.Delete(id);
            this.service.Save();
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
