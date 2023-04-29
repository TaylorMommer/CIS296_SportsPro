using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using SportsPro.Models.DataLayer;
using SportsPro.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("incidents")]

        public IActionResult List(string filter = "all")

        {
            var viewModel = new IncidentViewModel();
            List<Incident> incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .ToList();
            switch (filter.ToLower())
            {
                case "open":
                    incidents = incidents.Where(i => i.DateClosed == null).ToList();
                    viewModel.FilterString = "open";
                    break;
                case "unassigned":
                    incidents = incidents.Where(i => i.TechnicianID == null).ToList();
                    viewModel.FilterString = "unassigned";
                    break;
                default:
                    viewModel.FilterString = "all";
                    break;
            }

                incidents = incidents.OrderBy(i => i.DateOpened).ToList();
                ViewBag.SelectedFilter = filter;
                viewModel.Incidents = incidents;
                return View(viewModel);

        }

        public void StoreListsInViewBag()
        {
            ViewBag.Customers = context.Customers
            .OrderBy(c => c.FirstName)
            .ToList();

            ViewBag.Products = context.Products
            .OrderBy(c => c.Name)
            .ToList();

            ViewBag.Technicians = context.Technicians
            .OrderBy(c => c.Name)
            .ToList();

        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
            return View("AddEdit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
            var incident = context.Incidents.Find(id);
            return View("AddEdit", incident);
        }

        [HttpPost]
        public IActionResult Save(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                {
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);

                }
                context.SaveChanges();
                return RedirectToAction("List");

            }
            else
            {
                if (incident.IncidentID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                ViewBag.Customers = context.Customers.ToList();
                ViewBag.Products = context.Products.ToList();
                ViewBag.Technicians = context.Technicians.ToList();
                return View(incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}