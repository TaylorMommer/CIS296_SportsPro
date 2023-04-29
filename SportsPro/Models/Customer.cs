using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace SportsPro.Models
{
    public class Customer
    {
        public Customer()
        {
            Registrations = new List<Registration>();
        }

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(51, ErrorMessage="First name is too long.")]
		public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(51, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [StringLength(51, ErrorMessage = "Address is too long.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        [StringLength(51, ErrorMessage = "City is too long.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a valid state.")]
        [StringLength(51, ErrorMessage = "State is too long.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a valid postal code.")]
        [StringLength(21, ErrorMessage = "Postal Code is too long.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please select a country.")]
        public string CountryID { get; set; }
		public Country Country { get; set; }

        [RegularExpression(@"^((\+0?1\s)?)\(?\d{3}\)?[\s.\s]\d{3}[\s.-]\d{4}$",ErrorMessage = "Phone number must be in (999) 999-9999 format.")]
        public string Phone { get; set; }

		[Required(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(51, ErrorMessage = "Email is too long.")]
        [DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public string FullName => FirstName + " " + LastName;   // read-only property

        public List<Registration> Registrations { get; }
    }
}