using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Repository.Abstract
{
     public interface ISystemSettingRepository : IRepository<SystemSetting>
    {
         IQueryable<SystemSetting> GetByGroupName(string group);
    }
}
