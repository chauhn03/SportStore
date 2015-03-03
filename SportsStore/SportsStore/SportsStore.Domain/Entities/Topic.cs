
using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain.Entities
{
    public class Topic : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
    }
}
