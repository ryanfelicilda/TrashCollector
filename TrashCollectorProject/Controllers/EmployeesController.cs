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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            return View(db.Employee.Where(e => e.ApplicationId == currentUser));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            Employees employeeDetails = db.Employee.Where(e => e.Id == id).SingleOrDefault();
            return View(employeeDetails);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employees employeeCreate = new Employees();
            return View(employeeCreate);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employees employees)
        {
            if (ModelState.IsValid)
            {
                employees.ApplicationId = User.Identity.GetUserId();
                db.Employee.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            Employees employeeEdit = db.Employee.Where(e => e.Id == id).SingleOrDefault();
            return View(employeeEdit);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employees employees)
        {
            try
            {
                var employeeEdit = db.Employee.Find(id);
                employeeEdit.firstName = employees.firstName;
                employeeEdit.lastName = employees.lastName;
                employeeEdit.zipCode = employees.zipCode;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            Employees employeeDelete = db.Employee.Where(e => e.Id == id).SingleOrDefault();
            return View(employeeDelete);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employee.Find(id);
            db.Employee.Remove(employees);
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
