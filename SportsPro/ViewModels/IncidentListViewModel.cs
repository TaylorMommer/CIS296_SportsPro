using System;
using System.Collections.Generic;
using SportsPro.Models;

namespace SportsPro.ViewModels
{
    public class IncidentListViewModel
    {
        public string Filter { get; set; }

        public IEnumerable<Incident> Incidents { get; set; }

        /*public string Customer { get; set; }
        public string Product { get; set; }
        public string Technician { get; set; }
        public string Incident { get; set; }

        // use full properties for Incidents 
        // so can add 'All' item at beginning
        private List<Customer> customers;
        public List<Customer> Customers
        {
            get => customers;
            set
            {
                customers = new List<Customer> {
                    new Customer { CustomerID = "all", FirstName = "All", LastName = "All" }
                };
                customers.AddRange(value);
            }
        }

        private List<Product> products;
        public List<Product> Products
        {
            get => products;
            set
            {
                products = new List<Product> {
                    new Product { ProductID = "all", Name = "All" }
                };
                products.AddRange(value);
            }
        }
        private List<Technician> technicians;
        public List<Technician> Technicians
        {
            get => technicians;
            set
            {
                technicians = new List<Technician> {
                    new Technician { TechnicianID = "all", Name = "All" }
                };
                technicians.AddRange(value);
            }
        }

        private List<Incident> incidents;
        public new List<Incident> Incidents
        {
            get => incidents;
            set
            {
                incidents = new List<Incident> {
                    new Incident { IncidentID = "current", Title = "Current" }
                };
                incidents.AddRange(value);
            }
        }

        // methods to help view determine active link
        public new string CheckActiveIncident(string c) =>
            c.ToLower() == SelectedIncident.ToLower() ? "active" : "";*/
    }
    }
