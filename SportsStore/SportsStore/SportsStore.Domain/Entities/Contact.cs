
namespace SportsStore.Domain.Entities
{
    public class Contact : Entity
    {
        public int Id { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
