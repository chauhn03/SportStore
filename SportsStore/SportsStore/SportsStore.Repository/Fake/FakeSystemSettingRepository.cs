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
            this.systemSettings.Add(new SystemSetting { Id = 2, Group = "OnlineSupport", DisplayName = "Nick yahoo 1", Name = "YahooAccount1" });
            //this.systemSettings.Add(new SystemSetting { Id = 3, Group = "OnlineSupport", DisplayName = "Nick yahoo 2", Name = "YahooAccount2" });
            //this.systemSettings.Add(new SystemSetting { Id = 4, Group = "OnlineSupport", DisplayName = "Nick yahoo 3", Name = "YahooAccount3" });

            this.systemSettings.Add(new SystemSetting { Id = 5, Group = "OnlineSupport", DisplayName = "Nick skype 1", Name = "Skype1" });
            //this.systemSettings.Add(new SystemSetting { Id = 6, Group = "OnlineSupport", DisplayName = "Nick skype 2", Name = "Skype2" });
            //this.systemSettings.Add(new SystemSetting { Id = 7, Group = "OnlineSupport", DisplayName = "Nick skype 3", Name = "Skype3" });
            
            this.systemSettings.Add(new SystemSetting { Id = 8, Group = "OnlinePayment", DisplayName = "Paypal", Name = "Paypal" });
            this.systemSettings.Add(new SystemSetting { Id = 9, Group = "OnlinePayment", DisplayName = "Ngân lượng", Name = "NganLuong" });
            this.systemSettings.Add(new SystemSetting { Id = 10, Group = "OnlinePayment", DisplayName = "Bảo kim", Name = "BaoKim" });

            this.systemSettings.Add(new SystemSetting { Id = 11, Group = "VisitedCounter", Name = "VisitedCounterVisibility" });
            this.systemSettings.Add(new SystemSetting { Id = 12, Group = "VisitedCounter", Name = "VisitedDayCounter" });
            this.systemSettings.Add(new SystemSetting { Id = 13, Group = "VisitedCounter", Name = "VisitedWebCounter" });
            this.systemSettings.Add(new SystemSetting { Id = 14, Group = "VisitedCounter", Name = "VisitedMonthCounter" });
            this.systemSettings.Add(new SystemSetting { Id = 15, Group = "VisitedCounter", Name = "VisitedYearCounter" });
            this.systemSettings.Add(new SystemSetting { Id = 16, Group = "VisitedCounter", Name = "VisitedTotalCounter" });

            this.systemSettings.Add(new SystemSetting { Id = 17, Group = "MessageQuickBox", Name = "MessageQuickBoxVisibility" });
            this.systemSettings.Add(new SystemSetting { Id = 18, Group = "SocialNetwork", DisplayName = "Facebook", Name = "Facebook" });
            this.systemSettings.Add(new SystemSetting { Id = 19, Group = "SocialNetwork", DisplayName = "Google plus", Name = "GooglePlus" });
            this.systemSettings.Add(new SystemSetting { Id = 20, Group = "SocialNetwork", DisplayName = "Youtube", Name = "Youtube" });
            this.systemSettings.Add(new SystemSetting { Id = 21, Group = "SocialNetwork", DisplayName = "Twitter", Name = "Twitter" });
            this.systemSettings.Add(new SystemSetting { Id = 22, Group = "SocialNetwork", DisplayName = "Linkedin", Name = "Linkedin" });
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
