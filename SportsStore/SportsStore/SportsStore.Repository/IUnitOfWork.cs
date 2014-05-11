﻿namespace SportsStore.Repository
{
    using Repository.Abstract;
    using System;

    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }

        IProductRepository Products { get; }

        ICategoryRepository Categories { get; }

        void Commit();
    }
}