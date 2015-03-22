using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SportsStore.Domain.Entities
{
    public class Product : Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public string ProductNo { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage="Please enter a description")]
        [AllowHtml()]
        [Display(Name = "Thông tin sản phẩm")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage="Please specify a category")]        
        //public string Category { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        [Display(Name = "Nhóm sản phẩm")]
        public int CategoryId { get; set; }

        [Display(Name = "Hình ảnh")]
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
