﻿using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;
        public NinjectControllerFactory()
        {
            this.kernel = new StandardKernel();
            this.AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product> { 
            //    new Product{ Name = "Football", Price = 25 },
            //    new Product { Name = "Surf board", Price = 179},
            //    new Product { Name = "Running Shoes", Price = 95 }
            //}.AsQueryable());

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}