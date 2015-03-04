using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SportsStore.Domain.Entities
{
    public class News : Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [AllowHtml()]
        [Required(ErrorMessage = "Please enter a content")]
        public string Content { get; set; }

        public int TypeId { get; set; }        
    }
}
