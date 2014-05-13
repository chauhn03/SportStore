using System;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Repository;
using SportsStore.Repository.Fake;
using SportsStore.Service.Abstract;
using SportsStore.Service.EntityService;
using SportsStore.WebUI.Infrastructure.Concrete;

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
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

            kernel.Bind<IUnitOfWork>().To<FakeUnitOfWork>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IOrderService>().To<OrderService>().WithConstructorArgument("emailSettings", emailSettings);;
            kernel.Bind<ICategoryService>().To<CategoryService>();

            

            //kernel.Bind<IOrderProcessor>().To<FakeEmailOrderProcessor>().WithConstructorArgument("emailSettings", emailSettings);            
        }
    }
}