using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Repository.Fake
{
    public class FakeSystemSettingRepository : FakeRepository<SystemSetting>, ISystemSettingRepository
    {
        private List<SystemSetting> systemSettings;
        private static FakeSystemSettingRepository instance;

        public FakeSystemSettingRepository()
        {
            this.GenerateDummyData();
        }

        public static FakeSystemSettingRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeSystemSettingRepository();
                }

                return instance;
            }
        }


        private void GenerateDummyData()
        {
            this.systemSettings = new List<SystemSetting>();
            this.systemSettings.Add(new SystemSetting { Id = 1, Group = "SEO", Name = "GoogleEngine" });
            this.systemSettings.Add(new SystemSetting { Id = 2, Group = "OnlineSupport", Name = "YahooAccount1" });
            this.systemSettings.Add(new SystemSetting { Id = 3, Group = "OnlineSupport", Name = "YahooAccount2" });
            this.systemSettings.Add(new SystemSetting { Id = 4, Group = "OnlineSupport", Name = "YahooAccount3" });

            this.systemSettings.Add(new SystemSetting { Id = 5, Group = "OnlineSupport", Name = "Skype1" });
            this.systemSettings.Add(new SystemSetting { Id = 6, Group = "OnlineSupport", Name = "Skype2" });
            this.systemSettings.Add(new SystemSetting { Id = 7, Group = "OnlineSupport", Name = "Skype3" });
            this.systemSettings.Add(new SystemSetting { Id = 8, Group = "OnlinePayment", Name = "Paypal" });
            this.systemSettings.Add(new SystemSetting { Id = 9, Group = "OnlinePayment", Name = "NganLuong" });
            this.systemSettings.Add(new SystemSetting { Id = 10, Group = "OnlinePayment", Name = "BaoKim" });

            this.systemSettings.Add(new SystemSetting { Id = 11, Group = "VisitedCounter", Name = "VisitedCounterVisibility" });
            this.systemSettings.Add(new SystemSetting { Id = 12, Group = "VisitedCounter", Name = "VisitedDayCounter" });
            this.systemSettings.Add(new SystemSetting { Id = 13, Group = "VisitedCounter", Name = "VisitedWebCounter" });
            this.systemSettings.Add(new SystemSetting { Id = 14, Group = "VisitedCounter", Name = "VisitedMonthCounter" });
            this.systemSettings.Add(new SystemSetting { Id = 15, Group = "VisitedCounter", Name = "VisitedYearCounter" });
            this.systemSettings.Add(new SystemSetting { Id = 16, Group = "VisitedCounter", Name = "VisitedTotalCounter" });

            this.systemSettings.Add(new SystemSetting { Id = 17, Group = "MessageQuickBox", Name = "MessageQuickBoxVisibility" });
            this.systemSettings.Add(new SystemSetting { Id = 18, Group = "SocialNetwork", Name = "Facebook" });
            this.systemSettings.Add(new SystemSetting { Id = 19, Group = "SocialNetwork", Name = "Twitter" });
            this.systemSettings.Add(new SystemSetting { Id = 20, Group = "SocialNetwork", Name = "Linked" });
        }
        public override SystemSetting GetById(int id)
        {
            return this.systemSettings.Single(newsType => newsType.Id == id);
        }

        public override int Create(SystemSetting entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(SystemSetting entity)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<SystemSetting> GetAll()
        {
            return this.systemSettings.AsQueryable();
        }

        public override void Update(SystemSetting entity)
        {
            SystemSetting systemSetting = this.GetById(entity.Id);
            systemSetting.Value = entity.Value;
            systemSetting.Modified = DateTime.Now;
        }

        public IQueryable<SystemSetting> GetByGroupName(string group)
        {
            return this.systemSettings.Where(ss => ss.Group == group).AsQueryable();
        }
    }
}
