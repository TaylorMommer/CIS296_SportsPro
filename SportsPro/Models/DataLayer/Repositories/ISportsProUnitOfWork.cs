using System.Security.Claims;

namespace SportsPro.Models.DataLayer.Repositories
{
    public interface ISportsProUnitOfWork
    {
        public Repository<Customer> Customers { get; }
        public Repository<Incident> Incidents { get; }
        public Repository<Product> Products { get; }
        public Repository<Technician> Technicians { get; }

        public void Save();
    }
}
