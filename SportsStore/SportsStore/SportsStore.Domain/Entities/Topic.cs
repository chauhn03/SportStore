
using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain.Entities
{
    public class Topic : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Nhóm tin tức")]
        public string Name { get; set; }
    }
}
