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
            //current date
            string currentDay = DateTime.Today.DayOfWeek.ToString();
            Employee employeeInDB = context.Employees.Where(e => e.ApplicationId == userId ).SingleOrDefault();
            List<Customer> customersInZip = context.Customers.Where(c => c.Zipcode == employeeInDB.Zipcode).ToList();
            List<Customer> customersInZipAndCurrentDay = customersInZip.Where(c => c.PickUpDay == currentDay).ToList();
            return View("Index", customersInZipAndCurrentDay);
        }

        // GET: Employee/DayView
        public ActionResult DayView (int? id)
        {
            //if statements

            return View("Day View", ???);
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
