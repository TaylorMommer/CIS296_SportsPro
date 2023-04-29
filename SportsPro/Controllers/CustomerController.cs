using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using SportsPro.Models.DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProContext context { get; set; }

        public CustomerController(SportsProContext ctx)
        {
            context = ctx;
        }
        
        [TempData]
        public string Message { get; set; }

        [Route("Customers")]
        public IActionResult List()
        {
           // List<Customer> customers = context.Customers.OrderBy(c => c.LastName).ToList();
            //return View(customers);
            var Customers = context.Customers.OrderBy(g => g.FirstName).ToList();
            return View(Customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View("AddEdit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            var customer = context.Customers.Find(id);
            return View("AddEdit", customer);
        }


        [HttpPost]
        public RedirectToActionResult Edit(Customer customer)
        {
            if (customer.CustomerID == 0)
            {
                Message = $"Added Customer {customer.FullName}";
                context.Customers.Add(customer);
            }
            else
            {
                Message = $"Edited Customer {customer.FullName}";
                context.Customers.Update(customer);
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public IActionResult Save(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerID == 0)
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);

                }
                context.SaveChanges();
                return RedirectToAction("List");

            }
            else
            {
                if (customer.CustomerID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}