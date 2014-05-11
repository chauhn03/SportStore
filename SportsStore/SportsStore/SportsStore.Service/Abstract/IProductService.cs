namespace SportsStore.Service.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IProductService
    {
        IQueryable<SportsStore.Domain.Entities.Product> GetList();

        IQueryable<Domain.Entities.Product> GetByCategory(int? categoryId);

        Domain.Entities.Product GetById(int productId);
    }
}
