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
    public class SystemSettingService : Service<SystemSetting, ISystemSettingRepository>, ISystemSettingService
    {
        private IUnitOfWork unitOfWork;

        public SystemSettingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Repository = unitOfWork.SystemSettings;
        }

        public IQueryable<SystemSetting> GetByGroup(string group)
        {
            return this.Repository.GetByGroupName(group);
        }
    }
}
