namespace SportsPro.Models.DataLayer.Repositories
{
    public class SportsProUnitOfWork : ISportsProUnitOfWork
    {
        private SportsProContext context { get; set; }
        public SportsProUnitOfWork(SportsProContext ctx) => context = ctx;

        private Repository<Customer> customerData;
        public Repository<Customer> Customers
        {
            get
            {
                if (customerData == null)
                    customerData = new Repository<Customer>(context);
                return customerData;
            }
        }

        private Repository<Incident> incidentData;
        public Repository<Incident> Incidents
        {
            get
            {
                if (incidentData == null)
                    incidentData = new Repository<Incident>(context);
                return incidentData;
            }
        }

        private Repository<Product> productData;
        public Repository<Product> Products
        {
            get
            {
                if (productData == null)
                    productData = new Repository<Product>(context);
                return productData;
            }
        }

        private Repository<Technician> technicianData;
        public Repository<Technician> Technicians
        {
            get
            {
                if (technicianData == null)
                    technicianData = new Repository<Technician>(context);
                return technicianData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
