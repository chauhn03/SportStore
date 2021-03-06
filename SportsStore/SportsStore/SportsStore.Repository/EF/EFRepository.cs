﻿using System.Data.Entity;
using System.Linq;
using SportsStore.Repository.Abstract;

namespace SportsStore.Repository.EF
{
    // TODO: Add more base functionality
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> DbSet;

        public EFRepository(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public int Create(T entity)
        {
            DbSet.Add(entity);
            return 1;
        }

        public void Update(T entity)
        {
            this.DbSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }        
    }
}