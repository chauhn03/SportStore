using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SportsStore.Domain.Entities
{
    public class News : Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [AllowHtml()]
        [Required(ErrorMessage = "Please enter a content")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Chủ đề")]
        public int TypeId { get; set; }        
    }
}
