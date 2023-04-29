using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using SportsPro.Models.DataLayer;
using SportsPro.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private SportsProContext context { get; set; }
        public RegistrationController(SportsProContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult GetCustomer(string error = null)
        {
            var model = new RegistrationViewModel
            {
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
            };
            IQueryable<Customer> query = context.Customers;
            if (error == "not_select")
            {
                model.ErrorMessage = "Please select a customer!";
            }

            model.Customers = query.ToList();
            return View(model);
        }

        public ViewResult Registrations(string activeIncident = "All", string activeTechnician = "All")
        {
            var customerID = HttpContext.Session.GetInt32("customerId");
            var customerProducts = new List<Product>();

            if (customerID.HasValue && customerID > 0)
            {
                customerProducts = (from cr in context.Registrations
                                    join p in context.Products on cr.ProductID equals p.ProductID
                                    where cr.CustomerID == customerID
                                    select p).OrderBy(p => p.Name).ToList();
            }

            var model = new RegistrationViewModel
            {
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                Products = context.Products.OrderBy(p => p.Name).ToList(),
                CustomerProducts = customerProducts,
                ErrorMessage = TempData["message"].ToString()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Registrations(RegistrationViewModel inc)
        {
            var customerID = inc.CurrentCustomer.CustomerID;
            if (customerID == 0)
            {
                return RedirectToAction("GetCustomer", new { @error = "not_select" });
            }
            HttpContext.Session.SetInt32("customerId", customerID);

            var customer = context.Customers.Single(c => c.CustomerID == customerID);
            var model = new RegistrationViewModel
            {
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                Products = context.Products.OrderBy(p => p.Name).ToList(),
                CustomerProducts = (from cr in context.Registrations
                                    join p in context.Products on cr.ProductID equals p.ProductID
                                    where cr.CustomerID == customerID
                                    select p).OrderBy(p => p.Name).ToList(),
                ActiveCustomer = customer.FullName
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterProduct(RegistrationViewModel inc)
        {
            var customerID = HttpContext.Session.GetInt32("customerId");

            if (!customerID.HasValue || customerID == 0)
            {
                return RedirectToAction("GetCustomer", new { @error = "not_select" });
            }
            var customer = context.Customers.Single(c => c.CustomerID == customerID);

            context.Registrations.Add(new Registration
            {
                CustomerID = customerID.Value,
                ProductID = inc.CurrentProduct.ProductID
            });

            context.SaveChanges();

            return RedirectToAction("Registrations");
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            var product = context.Products.Find(productId);
            context.Products.Remove(product);
            context.SaveChanges();
            TempData["message"] = $"{product.Name} deleted from database";
            return RedirectToAction("Registrations", "Registration");
        }
    }
}
