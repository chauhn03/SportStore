using SportsStore.Domain.Entities;
using SportsStore.Repository;
using SportsStore.Repository.Abstract;
using SportsStore.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Service.EntityService
{
    public class OrderDetailService : Service<OrderDetail, IOrderDetailRepository>, IOrderDetailService
    {
        private IUnitOfWork unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Repository = unitOfWork.OrderDetails;
        }

        public IEnumerable<OrderDetail> GetByOrder(int orderId)
        {
            return this.Repository.GetByOrder(orderId);
        }
    }
}
