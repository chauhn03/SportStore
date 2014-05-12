namespace SportsStore.Repository
{
    using SportsStore.Repository.Abstract;
    using SportsStore.Repository.EF;

    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
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
                return customers ?? (customers = new EFCustomerRepository(db));
            }
        }

        public IProductRepository Products
        {
            get
            {
                return this.products ?? (this.products = new EFProductRepository(db));
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return this.catetories ?? (this.catetories = new EFCategoryRepository(db));
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
