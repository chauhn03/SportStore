using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Service.Abstract;

namespace SportsStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductService service;

        public AdminController(IProductService service)
        {
            this.service = service;
        }

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(this.service.GetAll());
        }

        public ViewResult Edit(int productId)
        {
            Product product = this.service.GetById(productId);
            return this.View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

                if (product.ProductId < 0)
                {
                    this.service.Add(product);
                }                

                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return this.RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values.
                return this.View(product);
            }
        }        

        public ViewResult Create()
        {
            return this.View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product product = this.service.GetById(productId);
            this.service.Delete(product);
            TempData["message"] = string.Format("{0} was deleted", product.Name);
            return this.RedirectToAction("Index");
        }
    }
}
