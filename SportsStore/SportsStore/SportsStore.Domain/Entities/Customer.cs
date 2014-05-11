namespace SportsStore.Domain.Entities
{
    public class Customer : Entity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}