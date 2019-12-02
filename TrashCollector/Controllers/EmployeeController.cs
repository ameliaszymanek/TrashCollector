using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            //view is going to be a list of customers with same zipcode
            string userId = User.Identity.GetUserId();
            Employee employeeInDB = context.Employees.Where(e => e.ApplicationId == userId ).SingleOrDefault();
            List<Customer> customers = context.Customers.Where(c => c.Zipcode == employeeInDB.Zipcode).ToList();
            return View(customers);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View(new Employee());
        }
      

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var employeeLoggedIn = User.Identity.GetUserId();
                employee.ApplicationId = employeeLoggedIn;
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index", "Employee", new { id = employee.EmployeeId });
            }

            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
