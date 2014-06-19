
namespace SportsStore.Domain.Entities
{
    public class News : Entity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int TypeId { get; set; }

        public string Content { get; set; }
    }
}
