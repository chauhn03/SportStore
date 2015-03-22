
using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain.Entities
{
    public class Category : Entity
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Tên nhóm")]
        public string Name { get; set; }        
    }
}
