using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using SportsPro.Models;
using SportsPro.Models.DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context { get; set; }
        private string message;

        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("Products")]
        public IActionResult List()
        {
            List<Product> products = context.Products.OrderBy(p => p.ReleaseDate).ToList();
            return View(products);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View("AddEdit", product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    context.Products.Add(product);
                    message = product.Name + " was added.";
                }
                else
                {
                    context.Products.Update(product);
                    message = product.Name + " was updated.";

                }
                context.SaveChanges();
                TempData["message"] = message;
                return RedirectToAction("List");

            }
            else
            {
                if (product.ProductID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            //TempData["message"] = $"{product} was deleted.";
            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            var p = context.Products.Find(product.ProductID);
            context.Products.Remove(p);
            context.SaveChanges();
            TempData["message"] = p.Name + " was deleted.";
            return RedirectToAction("List");
        }
    }
}