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

        private ICategoryRepository catetories;
        private ICustomerRepository customers;
        private IProductRepository products;

        public ICategoryRepository Categories
        {
            get
            {
                return this.catetories ?? (this.catetories = new EFCategoryRepository(db));
            }
        }

        public ICustomerRepository Customers
        {
            get
            {
                return customers ?? (customers = new EFCustomerRepository(db));
            }
        }

        public INewsRepository News
        {
            get { throw new System.NotImplementedException(); }
        }

        public IProductRepository Products
        {
            get
            {
                return this.products ?? (this.products = new EFProductRepository(db));
            }
        }

        /// <summary>
        /// Factoring method for starting a new UOW
        /// </summary>
        public static IUnitOfWork Begin()
        {
            return DataContainer.Resolve<IUnitOfWork>();
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


        public ITopicRepository Topics
        {
            get { throw new System.NotImplementedException(); }
        }


        public IOrderRepository Orders
        {
            get { throw new System.NotImplementedException(); }
        }


        public IOrderDetailRepository OrderDetails
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}