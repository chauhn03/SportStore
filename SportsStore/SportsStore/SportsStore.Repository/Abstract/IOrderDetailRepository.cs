using SportsStore.Domain.Entities;
using System.Linq;

namespace SportsStore.Repository.Abstract
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        IQueryable<OrderDetail> GetByOrder(int orderId);
    }
}
