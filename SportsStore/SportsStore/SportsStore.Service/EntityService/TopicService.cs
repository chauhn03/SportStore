using SportsStore.Domain.Entities;
using SportsStore.Repository.Abstract;
using SportsStore.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Service.EntityService
{
    public class TopicService : Service<Topic, ITopicRepository>, ITopicService
    {
    }
}
