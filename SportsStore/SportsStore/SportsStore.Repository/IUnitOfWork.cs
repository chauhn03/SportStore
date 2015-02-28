namespace SportsStore.Repository
{
    using System;
    using Repository.Abstract;

    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }

        IProductRepository Products { get; }

        ICategoryRepository Categories { get; }

        INewsRepository News { get; }

        ITopicRepository Topics { get; }

        void Commit();
    }
}