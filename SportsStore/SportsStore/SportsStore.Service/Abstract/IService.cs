﻿
using System.Linq;
namespace SportsStore.Service.Abstract
{
    public interface IService<T>
    {
        IQueryable<T> GetAll();

        T GetById(int productId);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);       
    }
}
