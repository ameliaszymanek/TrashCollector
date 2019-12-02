using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            Customer customerInDB = context.Customers.Where(c => c.ApplicationId == userId).SingleOrDefault();
            return View(customerInDB);

        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            Customer customer = context.Customers.Find(id);
           
            return View(customer);
        }

        //private ActionResult View(object p)
        //{
        //    throw new NotImplementedException();
        //}

        // GET: Customer/Create
        public ActionResult Create()
        {
            
            return View(new Customer());
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                var customerLoggedIn = User.Identity.GetUserId();
                customer.ApplicationId = customerLoggedIn;
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Details", "Customer", new { id = customer.CustomerId } );
            }
            
                return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            Customer customer = context.Customers.Find(id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Edit", "Customer", new { id = customer.ApplicationId });
        }


        // GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Customer/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
