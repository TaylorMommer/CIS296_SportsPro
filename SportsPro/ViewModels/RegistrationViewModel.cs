using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Collections.Generic;

namespace SportsPro.ViewModels
{
    public class RegistrationViewModel
    {
        private List<Customer> customers;
        public List<Customer> Customers
        {
            get => customers;
            set
            {
                customers = value;
            }
        }
        public string FilterString { get; set; }

        public Incident ActiveIncident { get; set; }
        public Technician ActiveTechnician { get; set; }
        public string ActiveCustomer { get; set; }

        public string Action { get; set; }

        public Incident CurrentIncident { get; set; }
        public Customer CurrentCustomer { get; set; }

        public Product CurrentProduct { get; set; }
        public int? CustomerID { get; set; }
        public string CustomerEmail { get; set; }

        private List<Product> products;

        public List<Product> Products
        {
            get => products;
            set
            {
                products = value;
            }
        }

        private List<Product> customerProducts;

        public List<Product> CustomerProducts
        {
            get => customerProducts;
            set
            {
                customerProducts = value;
            }
        }
        private List<Incident> incidents;

        public List<Incident> Incidents
        {
            get => incidents;
            set
            {
                incidents = value;
            }
        }

        public int? TechnicianID { get; set; }

        public string ErrorMessage { get; set; }

        private List<Technician> technicians;
        public List<Technician> Technicians
        {
            get => technicians;
            set
            {
                technicians = value;
            }
        }
        public string CheckActiveIncident(string i) =>
            i.ToLower() == ActiveIncident.ToString() ? "active" : "";
        public string CheckActiveTechnician(string t) =>
            t.ToLower() == ActiveTechnician.ToString() ? "active" : "";
    }


}
