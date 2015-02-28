using System.Web.Mvc;
namespace SportsStore.Domain.Entities
{
    public class News : Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int TypeId { get; set; }

        [AllowHtml()]
        public string Content { get; set; }
    }
}
