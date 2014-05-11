namespace SportsStore.Repository
{
    using SportsStore.Repository.Abstract;
    using SportsStore.Repository.EF;

    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext db = new DataContext();

        private ICustomerRepository customers;
        private IProductRepository products;
        private ICategoryRepository catetories;

        /// <summary>
        /// Factoring method for starting a new UOW
        /// </summary>
        public static IUnitOfWork Begin()
        {
            return DataContainer.Resolve<IUnitOfWork>();
        }
        
        public ICustomerRepository Customers
        {
            get
            {
                return customers ?? (customers = new CustomerRepository(db));
            }
        }

        public IProductRepository Products
        {
            get
            {
                return this.products ?? (this.products = new ProductRepository(db));
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return this.catetories ?? (this.catetories = new CategoryRepository(db));
            }
        }

        /// <summary>
        /// Commits changes made to all repositories
        /// </summary>
        public void Commit()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
