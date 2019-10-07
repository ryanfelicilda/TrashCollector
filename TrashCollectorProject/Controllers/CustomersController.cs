using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {

            return View(db.Customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            Customers customerDetails = db.Customer.Where(c => c.Id == id).SingleOrDefault();
            return View(customerDetails);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customers customerCreate = new Customers();
            return View(customerCreate);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers customers)
        {
            if (ModelState.IsValid)
            {
                customers.ApplicationId = User.Identity.GetUserId();
                db.Customer.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            Customers customerEdit = db.Customer.Where(c => c.Id == id).SingleOrDefault();
            return View(customerEdit);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customers customers)
        {
            try
            {
                var customerEdit = db.Customer.Find(id);
                customerEdit.firstName = customers.firstName;
                customerEdit.lastName = customers.lastName;
                customerEdit.streetAddress = customers.streetAddress;
                customerEdit.city = customers.city;
                customerEdit.state = customers.state;
                customerEdit.zipCode = customers.zipCode;
                customerEdit.balance = customers.balance;
                customerEdit.startPickupDate = customers.startPickupDate;
                customerEdit.pickupDay = customers.pickupDay;
                customerEdit.endPickupDate = customers.endPickupDate;
                customerEdit.extraPickupDate = customers.extraPickupDate;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            Customers customerDelete = db.Customer.Where(c => c.Id == id).SingleOrDefault();
            return View(customerDelete);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customer.Find(id);
            db.Customer.Remove(customers);
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
