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
        public ActionResult DayView (string Day)
        {
            string userId = User.Identity.GetUserId();
            Employee employeeInDB = context.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            List<Customer> customersInZip = context.Customers.Where(c => c.Zipcode == employeeInDB.Zipcode).ToList();
            List<Customer> customersInZipAndDay = customersInZip.Where(c => c.PickUpDay == Day).ToList();
            return View("DayView", customersInZipAndDay);
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

        // GET: Employee/Edit/Customer PickupConfirmed
        public ActionResult Edit(int id)
        {
            var CustomerToEdit = context.Customers.Where(c => c.CustomerId == id).SingleOrDefault();
            return View(CustomerToEdit);
        }

        // POST: Employee/Edit/Customer PickupConfirmed
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            var CustomerToEdit = context.Customers.Where(c => c.CustomerId == id).SingleOrDefault();
            CustomerToEdit.PickupConfirmed = customer.PickupConfirmed;
            if(CustomerToEdit.PickupConfirmed == true)
            {
                CustomerToEdit.Balance += 20.25;
                context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }

            CustomerToEdit.PickupConfirmed = false;
            context.SaveChanges();
            return RedirectToAction("Index","Employee");

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
