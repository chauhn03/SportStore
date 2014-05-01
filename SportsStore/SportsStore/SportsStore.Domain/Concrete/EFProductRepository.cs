﻿using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.Product> Products
        {
            get
            {
                return context.Products;
            }
        }


        public Entities.Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }


        public void SaveProduct(Entities.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
